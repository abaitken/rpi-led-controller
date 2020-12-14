using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationInstant : Animation
    {
        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            return 1;
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            for (int index = 0; index < controller.LightCount; index++)
                controller[index].Color = pattern[index];

            controller.Update();
            return AnimationState.Complete;
        }
    }
}
