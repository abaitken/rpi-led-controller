using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    /// <summary>
    /// Sets the pattern but alters the brightness from min to max a random number of times
    /// </summary>
    public class AnimationFlashing : Animation
    {
        private int _remainingIterations;
        private bool _on;

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _remainingIterations = random.Next(4, 8);

            for (int index = 0; index < controller.LightCount; index++)
                controller[index].Color = pattern[index];

            controller.Update();

            _on = true;
            return _remainingIterations;
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            if (_on)
            {
                controller.Brightness = 0;
                _on = false;
            }
            else
            {
                controller.Brightness = (controller.DefaultBrightness);
                _on = true;
                _remainingIterations--;
            }

            controller.Update();

            if (_remainingIterations > 0)
                return AnimationState.InProgress;

            controller.Brightness = (controller.DefaultBrightness);
            return AnimationState.Complete;
        }
    }
}
