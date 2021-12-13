using Lighting.Animations;
using Lighting.Dynamic;
using Lighting.Patterns;
using Lighting.Scenes;
using Lighting.Timings;
using System.Collections.Generic;

namespace Lighting.Demos
{
    public class DemoRandom : DemoSceneStack
    {
        protected override IEnumerable<IScene> CreateScenes()
        {
            yield return new SceneRandom();
        }
    }
}
