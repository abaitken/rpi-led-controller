using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationSlideRight : Animation
    {
        private int _offset;

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _offset = 0;
            return controller.LightCount;
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            for (int index = _offset; index >= 0; index--)
                controller[index].Color = pattern[controller.LightCount - 1 - _offset + index];

            controller.Update();
            _offset++;
            if (_offset < controller.LightCount)
                return AnimationState.InProgress;

            return AnimationState.Complete;
        }
    }
}
