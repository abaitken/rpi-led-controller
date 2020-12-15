using Lighting.Animations;
using Lighting.Dynamic;
using Lighting.Patterns;
using Lighting.Timings;
using System;

namespace Lighting.Demos
{
    public class DemoRandom : Demo
    {
        IAnimation _currentAnimation;
        ITiming _currentTiming;
        IPattern _currentPattern;

        private AnimationFactory _animationFactory;
        private PatternFactory _patternFactory;
        private TimingFactory _timingFactory;

        void NextScene(ILightingController controller, Random random)
        {
            var nextPattern = _patternFactory.GenerateRandom();

            if (_currentPattern != null)
            {
                int i = 0;
                while (i < 10 && _currentPattern.GetType() == typeof(PatternClear) && nextPattern.GetType() == typeof(PatternClear))
                {
                    nextPattern = _patternFactory.GenerateRandom();
                    i++;
                }

                // TODO : Remove this?
                // NOTE : Temporary implementation to prevent unlit/black colour being used in succession
                if (i >= 9)
                {
                    nextPattern = new PatternRandomSolidColor();
                }
            }

            _currentPattern = nextPattern;
            _currentTiming = _timingFactory.GenerateRandom();
            _currentAnimation = _animationFactory.GenerateRandom();

            _currentPattern.Reset(controller, random);
            var totalSteps = _currentAnimation.Begin(controller, _currentPattern, random);
            _currentTiming.Reset(totalSteps);
        }

        public override void Begin(ILightingController controller, Random random)
        {
            _animationFactory = new AnimationFactory(TypeSource<IAnimation>.FromThisAssembly(), random);
            _patternFactory = new PatternFactory(TypeSource<IPattern>.FromThisAssembly().Exclude<PatternSolidColor>(), random);
            _timingFactory = new TimingFactory(TypeSource<ITiming>.FromThisAssembly(), random);
            NextScene(controller, random);
        }

        public override DemoState Step(ILightingController controller, Random random)
        {
            if (_currentAnimation.Step(controller, _currentPattern, random) == AnimationState.Complete)
            {
                NextScene(controller, random);
                return DemoState.InProgress;
            }
            _currentTiming.Delay();
            _currentPattern.NextState(random);

            return DemoState.InProgress;
        }
    }
}
