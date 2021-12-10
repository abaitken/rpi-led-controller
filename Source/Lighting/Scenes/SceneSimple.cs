using Lighting.Animations;
using Lighting.Patterns;
using Lighting.Timings;
using System;

namespace Lighting.Scenes
{
    public abstract class SceneSimple : Scene
    {
        private IAnimation _animation;
        private ITiming _timing;
        private IPattern _pattern;

        public override sealed void Begin(ILightingController controller, Random random)
        {
            _pattern = CreatePattern();
            _pattern.Reset(controller, random);
            _animation = CreateAnimation();
            var totalSteps = _animation.Begin(controller, _pattern, random);
            _timing = CreateTiming();
            _timing.Reset(totalSteps);
        }

        public abstract IPattern CreatePattern();
        public abstract ITiming CreateTiming();
        public abstract IAnimation CreateAnimation();

        public override sealed SceneState Step(ILightingController controller, Random random)
        {
            if (_animation.Step(controller, _pattern, random) == AnimationState.Complete)
            {
                return SceneState.Complete;
            }
            _timing.Delay();
            _pattern.NextState(random);

            return SceneState.InProgress;
        }

    }
}
