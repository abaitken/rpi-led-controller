using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationRandom : Animation
    {
        private int _remainingIterations;

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _remainingIterations = random.Next(200, 400);
            return _remainingIterations;
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            int index = random.Next(controller.LightCount);
            controller[index].Color = pattern[index];
            controller.Update();
            _remainingIterations--;
            if (_remainingIterations > 0)
                return AnimationState.InProgress;

            return AnimationState.Complete;
        }
    }
}
