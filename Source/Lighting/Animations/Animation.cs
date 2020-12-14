using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public abstract class Animation : IAnimation
    {
        public abstract int Begin(ILightingController controller, IPattern pattern, Random random);
        public abstract AnimationState Step(ILightingController controller, IPattern pattern, Random random);
    }
}
