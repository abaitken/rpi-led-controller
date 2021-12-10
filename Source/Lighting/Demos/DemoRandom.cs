using Lighting.Animations;
using Lighting.Dynamic;
using Lighting.Patterns;
using Lighting.Scenes;
using Lighting.Timings;

namespace Lighting.Demos
{
    public class DemoRandom : DemoSceneStack
    {
        protected override sealed IScene FirstScene()
        {
            return new SceneRandom();
        }

        protected override sealed IScene NextScene()
        {
            return null;
        }
    }
}
