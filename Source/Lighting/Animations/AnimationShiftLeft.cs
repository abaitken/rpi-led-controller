using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationShiftLeft : Animation
    {
        private int _offset;

        public override int Begin(ILightingController controller, IPatternInformation pattern, Random random)
        {
            _offset = 0;
            return controller.LightCount;
        }

        public override AnimationState Step(ILightingController controller, IPatternInformation pattern, Random random)
        {
            for (int index = 0; index < controller.LightCount; index++)
            {
                int offsetIndex = index - _offset;
                if (offsetIndex < 0)
                    offsetIndex = controller.LightCount + offsetIndex;
                controller[offsetIndex].Color = pattern[index];
            }

            controller.Update();
            _offset++;
            if (_offset < controller.LightCount)
                return AnimationState.InProgress;

            return AnimationState.Complete;
        }
    }
}
