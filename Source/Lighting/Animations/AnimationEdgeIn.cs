using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    /// <summary>
    /// Sets the lights starting from the outside edges moving to the middle
    /// </summary>
    public class AnimationEdgeIn : Animation
    {
        private int _middle;
        private int _left;
        private int _right;

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _middle = (int)Math.Floor(controller.LightCount / 2d);
            _left = 0;
            _right = controller.LightCount - 1;
            return controller.LightCount;
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            if (_left <= _middle)
            {
                controller[_left].Color = pattern[_left];
                _left++;
            }
            if (_right >= _middle)
            {
                controller[_right].Color = pattern[_right];
                _right--;
            }

            controller.Update();

            if (_left >= _middle && _right <= _middle)
                return AnimationState.Complete;
            return AnimationState.InProgress;
        }
    }
}
