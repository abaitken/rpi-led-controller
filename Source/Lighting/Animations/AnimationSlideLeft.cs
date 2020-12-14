using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationSlideLeft : Animation
    {
        private int _index;

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _index = controller.LightCount - 1;
            return controller.LightCount;
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            _index--;

            for (int index = _index; index < controller.LightCount; index++)
                controller[index].Color = pattern[index];

            controller.Update();
            if (_index > 0)
                return AnimationState.InProgress;

            return AnimationState.Complete;
        }
    }
}
