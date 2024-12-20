using Lighting.Animations;
using Lighting.Dynamic;
using Lighting.Palette;
using Lighting.Patterns;
using Lighting.Timings;
using System;

namespace Lighting.Scenes
{
    /// <summary>
    /// Selects a random animation, pattern and timing and runs them
    /// </summary>
    public class SceneRandom : Scene
    {
        IAnimation _currentAnimation;
        ITiming _currentTiming;
        IPattern _currentPattern;

        private readonly AnimationFactory _animationFactory;
        private readonly PatternFactory _patternFactory;
        private readonly TimingFactory _timingFactory;

        public SceneRandom()
        {
            _animationFactory = new AnimationFactory(TypeSource<IAnimation>.FromThisAssembly());
            _patternFactory = new PatternFactory(TypeSource<IPattern>.FromThisAssembly());
            _timingFactory = new TimingFactory(TypeSource<ITiming>.FromThisAssembly());
        }

        public override void Begin(ILightingController controller, Random random, IPalette palette)
        {
            var nextPattern = _patternFactory.GenerateRandom(random);

            if (_currentPattern != null)
            {
                int i = 0;
                while (i < 10 && _currentPattern.GetType() == typeof(PatternClear) && nextPattern.GetType() == typeof(PatternClear))
                {
                    nextPattern = _patternFactory.GenerateRandom(random);
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
            _currentTiming = _timingFactory.GenerateRandom(random);
            _currentAnimation = _animationFactory.GenerateRandom(random);

            _currentPattern.Reset(controller, random, palette);
            var totalSteps = _currentAnimation.Begin(controller, _currentPattern, random);
            _currentTiming.Reset(totalSteps);
        }

        public override SceneState Step(ILightingController controller, Random random, IPalette palette)
        {
            if (_currentAnimation.Step(controller, _currentPattern, random) == AnimationState.Complete)
            {
                return SceneState.Complete;
            }
            _currentTiming.Delay();
            _currentPattern.NextState(random, palette);

            return SceneState.InProgress;
        }
    }
}
