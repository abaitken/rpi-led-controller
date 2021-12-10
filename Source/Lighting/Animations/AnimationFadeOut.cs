using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    /// <summary>
    /// Sets all lights as per the pattern, but fades out the brightness
    /// </summary>
    public class AnimationFadeOut : Animation
    {
        public byte BrightnessAdjust { get; set; } = 1;
        public byte BrightnessStart { get; set; } = 150;
        public byte BrightnessEnd { get; set; } = 0;
        private byte _brightness;

        public override int Begin(ILightingController controller, IPatternInformation pattern, Random random)
        {
            _brightness = BrightnessStart;

            controller.Brightness = _brightness;
            controller.Update();

            var range = BrightnessStart - BrightnessEnd;
            return (int)Math.Ceiling((double)range / BrightnessAdjust);
        }

        public override AnimationState Step(ILightingController controller, IPatternInformation pattern, Random random)
        {
            for (int index = 0; index < controller.LightCount; index++)
                controller[index].Color = pattern[index];

            _brightness -= BrightnessAdjust;
            if (_brightness < BrightnessEnd)
                _brightness = BrightnessEnd;

            controller.Brightness = _brightness;
            controller.Update();

            if (_brightness > BrightnessEnd)
                return AnimationState.InProgress;

            return AnimationState.Complete;
        }
    }
}
