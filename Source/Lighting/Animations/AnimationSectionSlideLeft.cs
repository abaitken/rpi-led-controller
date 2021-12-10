using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationSectionSlideLeft : Animation
    {
        private int _index;

        public AnimationSectionSlideLeft()
        {
            SectionLength = 10;
        }

        public int SectionLength { get; set; }

        public override int Begin(ILightingController controller, IPatternInformation pattern, Random random)
        {
            _index = controller.LightCount - 1;
            return controller.LightCount + SectionLength;
        }

        public override AnimationState Step(ILightingController controller, IPatternInformation pattern, Random random)
        {
            if (_index >= 0)
                controller[_index].Color = pattern[_index];

            if (_index + SectionLength < controller.LightCount)
                controller[_index + SectionLength].Color = Color.Black;

            controller.Update();
            _index--;
            if (_index + SectionLength >= 0)
                return AnimationState.InProgress;

            return AnimationState.Complete;
        }
    }
}
