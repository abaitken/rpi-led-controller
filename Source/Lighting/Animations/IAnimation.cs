using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public interface IAnimation
    {
        int Begin(ILightingController controller, IPattern pattern, Random random);
        AnimationState Step(ILightingController controller, IPattern pattern, Random random);
    }
}
