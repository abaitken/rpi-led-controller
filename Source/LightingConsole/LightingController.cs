using Lighting;
using rpi_ws281x;
using System.Linq;

namespace LightingConsole
{
    internal class LightingController : ILightingController
    {
        private Controller _controller;
        private WS281x _rpi;

        public LightingController()
        {

            //The default settings uses a frequency of 800000 Hz and the DMA channel 10.
            var settings = Settings.CreateDefaultSettings();

            //Use 16 LEDs and GPIO Pin 18.
            //Set brightness to maximum (255)
            //Use Unknown as strip type. Then the type will be set in the native assembly.
            _controller = settings.AddController(16, Pin.Gpio18, StripType.WS2812_STRIP, ControllerType.SPI, 255, false);

            _rpi = new WS281x(settings);
            //{
            //    //Set the color of the first LED of controller 0 to blue
            //    controller.SetLED(0, Color.Blue);
            //    //Set the color of the second LED of controller 0 to red
            //    controller.SetLED(1, Color.Red);
            //    rpi.Render();
            //}
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

        public ILight this[int index] => new Light(_controller, index);

        public int LightCount => 300;

        public byte DefaultBrightness => 150;

        public byte Brightness { get => _controller.Brightness; set => _controller.Brightness = value; }

        public void Update()
        {
            _rpi.Render();
        }
    }
}