using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    public class AnimationCenterOut : Animation
    {
        private int _left;
        private int _right;

        public override int Begin(ILightingController controller, IPattern pattern, Random random)
        {
            _left = (int)Math.Floor((double)controller.LightCount / 2);
            _right = (int)Math.Ceiling((double)controller.LightCount / 2);
            return controller.LightCount;
        }

        public override AnimationState Step(ILightingController controller, IPattern pattern, Random random)
        {
            if (_left >= 0)
            {
                controller[_left].Color = pattern[_left];
                _left--;
            }
            if (_right < controller.LightCount)
            {
                controller[_right].Color = pattern[_right];
                _right++;
            }

            controller.Update();

            if (_left < 0 && _right >= controller.LightCount)
                return AnimationState.Complete;
            return AnimationState.InProgress;
        }
    }
}
