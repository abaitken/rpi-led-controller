using Lighting;
using Lighting.Animations;
using Lighting.Demos;
using Lighting.Patterns;
using Lighting.Scenes;
using Lighting.Timings;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LightingServer
{
    class LightingService : BackgroundService, ILightingService
    {
        public string CurrentDemo { get; set; } = "Ready";

        class NullController : LightingController
        {
            public override ILight this[int index] => new Light();

            public override byte Brightness { get; set; }

            public override int LightCount => 1;

            public override byte DefaultBrightness => 150;

            public override void Update()
            {
            }

            private class Light : ILight
            {
                public Color Color { get; set; }
            }
        }

        class ServiceReadyDemo : DemoSceneStack
        {
            protected override IEnumerable<IScene> CreateScenes()
            {
                yield return new SceneClear();
                yield return new ServiceReadyScene();
            }

            private class ServiceReadyScene : Scene
            {
                private int _currentStep;
                private bool _onOrOff;

                private IPattern _on;
                private IPattern _off;
                private IAnimation _animation;
                private ITiming _timing;

                public override void Begin(ILightingController controller, Random random)
                {
                    _currentStep = 0;

                    _on = new PatternConfigured
                    {
                        Configured = new[] { Color.Green }
                    };
                    _on.Reset(controller, random);

                    _off = new PatternConfigured
                    {
                        Configured = new[] { Color.Red }
                    };
                    _off.Reset(controller, random);

                    _animation = new AnimationInstant();
                    var totalSteps = _animation.Begin(controller, _on, random);
                    _timing = new TimingConstant
                    {
                        Milliseconds = 500
                    };
                    _timing.Reset(totalSteps);
                }

                public override SceneState Step(ILightingController controller, Random random)
                {
                    var pattern = _onOrOff ? _on : _off;
                    _onOrOff = !_onOrOff;

                    _animation.Step(controller, pattern, random);
                    _timing.Delay();
                    pattern.NextState(random);

                    _currentStep++;

                    if(_currentStep < 30)
                        return SceneState.InProgress;

                    return SceneState.Complete;
                }
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();
            var controller = new NullController();
            var random = new Random();

            while (!stoppingToken.IsCancellationRequested)
            {
                var currentDemo = CurrentDemo;
                var demo = new ServiceReadyDemo();
                demo.Begin(controller, random);

                while (demo.Step(controller, random) == DemoState.InProgress)
                {
                    if (stoppingToken.IsCancellationRequested)
                        break;

                    //if (currentDemo != CurrentDemo)
                        // TODO !
                }
            }
        }
    }
}
