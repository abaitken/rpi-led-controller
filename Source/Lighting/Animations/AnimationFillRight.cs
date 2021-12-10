using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    /// <summary>
    /// Sets all lights as per the pattern, but applies new values from right to left
    /// </summary>
    public class AnimationFillRight : Animation
    {
        private int _index;

        public override int Begin(ILightingController controller, IPatternInformation pattern, Random random)
        {
            _index = controller.LightCount - 1;
            return controller.LightCount;
        }

        public override AnimationState Step(ILightingController controller, IPatternInformation pattern, Random random)
        {
            controller[_index].Color = pattern[_index];

            controller.Update();
            _index--;

            if (_index >= 0)
                return AnimationState.InProgress;
            return AnimationState.Complete;
        }
    }
}
