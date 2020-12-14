using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationFadeOut : Animation
    {
        private const byte BRIGHTNESS_STEP_ADJUST = 1;
        private byte _brightness;

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _brightness = controller.DefaultBrightness;

            return (int)Math.Ceiling((double)controller.Brightness / BRIGHTNESS_STEP_ADJUST);
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            if(_brightness == controller.DefaultBrightness)
            {
                for (int index = 0; index < controller.LightCount; index++)
                    controller[index].Color = pattern[index];

                controller.Update();
            }
            controller.Brightness = (_brightness);
            _brightness -= BRIGHTNESS_STEP_ADJUST;

            if (_brightness > 0)
                return AnimationState.InProgress;

            for (int index = 0; index < controller.LightCount; index++)
                controller[index].Color = Color.Black;

            controller.Brightness = (controller.Brightness);
            controller.Update();

            return AnimationState.Complete;
        }
    }
}
