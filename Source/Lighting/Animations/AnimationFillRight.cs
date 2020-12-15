using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationFillRight : Animation
    {
        private int _index;

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _index = controller.LightCount - 1;
            return controller.LightCount;
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            controller[_index].Color = pattern[_index];

            controller.Update();
            _index--;

            if (_index >= 0)
                return AnimationState.InProgress;
            return AnimationState.Complete;
        }
    }
}
