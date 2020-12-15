using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationSectionSlideRight : Animation
    {
        private int _index;
        public AnimationSectionSlideRight()
        {
            SectionLength = 10;
        }
        public int SectionLength { get; set; }

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _index = 0;
            return controller.LightCount + SectionLength;
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            if (_index < controller.LightCount)
                controller[_index].Color = pattern[_index];

            if (_index - SectionLength >= 0)
                controller[_index - SectionLength].Color = Color.Black;

            controller.Update();

            _index++;
            if (_index - SectionLength < controller.LightCount)
                return AnimationState.InProgress;

            return AnimationState.Complete;
        }
    }
}
