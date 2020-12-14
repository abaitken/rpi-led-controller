﻿using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationSlideRight : Animation
    {
        private int _index;

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _index = -1;
            return controller.LightCount;
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            _index++;

            for (int index = _index; index >= 0; index++)
                controller[index].Color = pattern[index];

            controller.Update();
            if (_index < controller.LightCount)
                return AnimationState.InProgress;

            return AnimationState.Complete;
        }
    }
}
