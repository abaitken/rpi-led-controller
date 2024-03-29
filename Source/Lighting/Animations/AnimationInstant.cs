﻿using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    /// <summary>
    /// Instantly applies the pattern to the lighting strip
    /// </summary>
    public class AnimationInstant : Animation
    {
        public override int Begin(ILightingController controller, IPatternInformation pattern, Random random)
        {
            return 1;
        }

        public override AnimationState Step(ILightingController controller, IPatternInformation pattern, Random random)
        {
            for (int index = 0; index < controller.LightCount; index++)
                controller[index].Color = pattern[index];

            controller.Update();
            return AnimationState.Complete;
        }
    }
}
