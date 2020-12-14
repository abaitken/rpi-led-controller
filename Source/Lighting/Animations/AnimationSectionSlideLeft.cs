using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationSectionSlideLeft : Animation
    {
        const int SECTION_LENGTH = 10;
        private int _index;

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _index = controller.LightCount;
            return controller.LightCount + SECTION_LENGTH;
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            _index--;
            controller[_index].Color = pattern[_index];

            if (_index + SECTION_LENGTH < controller.LightCount)
                controller[_index + SECTION_LENGTH].Color = Color.Black;

            controller.Update();
            if (_index + SECTION_LENGTH >= 0)
                return AnimationState.InProgress;

            return AnimationState.Complete;
        }
    }
}
