using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public abstract class Animation : IAnimation
    {
        public abstract int Begin(ILightingController controller, IPatternInformation pattern, Random random);
        public abstract AnimationState Step(ILightingController controller, IPatternInformation pattern, Random random);
    }
}
