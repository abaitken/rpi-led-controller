using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationSlideLeft : Animation
    {
        private int _offset;

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _offset = controller.LightCount - 1;
            return controller.LightCount;
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            for (int index = _offset; index < controller.LightCount; index++)
                controller[index].Color = pattern[index - _offset];

            controller.Update();
            _offset--;
            if (_offset >= 0)
                return AnimationState.InProgress;

            return AnimationState.Complete;
        }
    }
}
