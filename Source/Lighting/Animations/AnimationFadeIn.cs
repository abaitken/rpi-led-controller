using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    /// <summary>
    /// Sets all lights as per the pattern, but fades in the brightness
    /// </summary>
    public class AnimationFadeIn : Animation
    {
        public byte BrightnessAdjust { get; set; } = 1;
        public byte BrightnessStart { get; set; } = 0;
        public byte BrightnessEnd { get; set; } = 150;

        private byte _brightness;

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _brightness = BrightnessStart;

            controller.Brightness = _brightness;
            controller.Update();

            var range = BrightnessEnd - BrightnessStart;
            return (int)Math.Ceiling((double)range / BrightnessAdjust);
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            for (int index = 0; index < controller.LightCount; index++)
                controller[index].Color = pattern[index];

            _brightness += BrightnessAdjust;
            if (_brightness > BrightnessEnd)
                _brightness = BrightnessEnd;

            controller.Brightness = _brightness;
            controller.Update();

            if (_brightness < BrightnessEnd)
                return AnimationState.InProgress;

            return AnimationState.Complete;
        }
    }
}
