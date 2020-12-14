using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationShiftLeft : Animation
    {
        private int _offset;

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _offset = controller.LightCount;
            return controller.LightCount;
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            for (int index = 0; index < controller.LightCount; index++)
            {
                int offsetIndex = index + _offset;
                if (offsetIndex < 0)
                    offsetIndex = controller.LightCount + offsetIndex;
                controller[index].Color = pattern[offsetIndex];
            }

            controller.Update();
            _offset--;
            if (_offset >= 0)
                return AnimationState.InProgress;

            return AnimationState.Complete;
        }
    }
}
