using Lighting.Animations;
using Lighting.Dynamic;
using Lighting.Patterns;
using Lighting.Timings;
using System;

namespace Lighting.Demos
{
    public class TextProgrammableDemo : Demo
    {
        IAnimation _currentAnimation;
        ITiming _currentTiming;
        IPattern _currentPattern;
        private CommandReader _commands;
        private readonly string _commandText;

        public TextProgrammableDemo(string commandText)
        {
            _commandText = commandText;
        }

        class CommandReader
        {
            int index;
            private readonly string _commands;
            private AnimationFactory _animationFactory;
            private PatternFactory _patternFactory;
            private TimingFactory _timingFactory;

            IAnimation _currentAnimation;
            ITiming _currentTiming;
            IPattern _currentPattern;

            public CommandReader(string commands, Random random)
            {
                _animationFactory = new AnimationFactory(TypeSource<IAnimation>.FromThisAssembly(), random);
                _patternFactory = new PatternFactory(TypeSource<IPattern>.FromThisAssembly(), random);
                _timingFactory = new TimingFactory(TypeSource<ITiming>.FromThisAssembly(), random);
                _commands = commands;
            }

            internal bool NextScene(out IAnimation animation, out IPattern pattern, out ITiming timing)
            {
                // TODO : Parse command text and create next animation/pattern/timing as required
                // Read up to (including) the next animation and return
                // Use visitor to assign/generate values for all types

                // NOTE : Do not return null!
                _currentAnimation = null /* TODO */;
                _currentPattern = null /* TODO */;
                _currentTiming = null /* TODO */;


                animation = _currentAnimation;
                pattern = _currentPattern;
                timing = _currentTiming;
                return false;
            }
        }

        public override void Begin(ILightingController controller, Random random)
        {
            _commands = new CommandReader(_commandText, random);
            NextScene(controller, random);
        }

        bool NextScene(ILightingController controller, Random random)
        {
            return _commands.NextScene(out _currentAnimation, out _currentPattern, out _currentTiming);
        }

        public override DemoState Step(ILightingController controller, Random random)
        {
            if (_currentAnimation == null || _currentTiming == null || _currentPattern == null)
                return DemoState.Complete;

            if (_currentAnimation.Step(controller, _currentPattern, random) == AnimationState.Complete)
            {
                if(!NextScene(controller, random))
                    return DemoState.Complete;
                return DemoState.InProgress;
            }
            _currentTiming.Delay();
            _currentPattern.NextState(random);

            return DemoState.InProgress;
        }
    }
}
