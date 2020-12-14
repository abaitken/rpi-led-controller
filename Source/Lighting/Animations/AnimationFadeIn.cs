using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationFadeIn : Animation
    {
        private const byte BRIGHTNESS_STEP_ADJUST = 1;
        private byte _brightness;

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _brightness = 0;

            controller.Update();

            return (int)Math.Ceiling((double)controller.Brightness / BRIGHTNESS_STEP_ADJUST);
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            if(_brightness == 0)
            {
                for (int index = 0; index < controller.LightCount; index++)
                    controller[index].Color = pattern[index];
                controller.Update();
            }
            controller.Brightness = _brightness;
            _brightness += BRIGHTNESS_STEP_ADJUST;

            if (_brightness < controller.Brightness)
                return AnimationState.InProgress;

            controller.Brightness = (controller.Brightness);
            controller.Update();

            return AnimationState.Complete;
        }
    }
}
