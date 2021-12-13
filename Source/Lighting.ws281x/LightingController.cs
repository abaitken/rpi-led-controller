using Lighting;
using rpi_ws281x;
using System;
using System.Linq;

namespace LightingConsole
{
    public class LightingController : Lighting.LightingController
    {
        private readonly Controller _controller;
        private readonly WS281x _ws281x;
        private readonly int _lightCount;
        private readonly byte _defaultBrightness;

        public LightingController(int lightCount, int controlPin, ushort defaultBrightness = 150)
        {
            _lightCount = lightCount;
            _defaultBrightness = defaultBrightness < 0 || defaultBrightness > 255 ? (byte)150 : (byte)defaultBrightness;

            //The default settings uses a frequency of 800000 Hz and the DMA channel 10.
            var settings = Settings.CreateDefaultSettings();

            //Use Unknown as strip type. Then the type will be set in the native assembly.
            _controller = settings.AddController(_lightCount, GetPin(controlPin), StripType.WS2812_STRIP, ControllerType.SPI, _defaultBrightness, false);

            _ws281x = new WS281x(settings);
        }

        private static Pin GetPin(int controlPin)
        {
            return controlPin switch
            {
                10 => Pin.Gpio10,
                12 => Pin.Gpio12,
                13 => Pin.Gpio13,
                18 => Pin.Gpio18,
                19 => Pin.Gpio19,
                21 => Pin.Gpio21,
                31 => Pin.Gpio31,
                _ => throw new ArgumentOutOfRangeException(nameof(controlPin), "Unexpected pin number"),
            };
        }

        struct Light : ILight
        {
            private readonly Controller _controller;
            private readonly int _index;

            public Light(Controller controller, int index)
            {
                _controller = controller;
                _index = index;
            }

            public Color Color 
            { 
                get => _controller.LEDs.ElementAt(_index).Color.ToColor(); 
                set => _controller.SetLED(_index, value.ToColor()); 
            }
        }

        public override ILight this[int index] => new Light(_controller, index);

        public override int LightCount => _lightCount;

        public override byte DefaultBrightness => _defaultBrightness;

        public override byte Brightness { get => _controller.Brightness; set => _controller.Brightness = value; }

        public override void Update()
        {
            _ws281x.Render();
        }
    }
}