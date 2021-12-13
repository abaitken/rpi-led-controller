using Lighting.Scenes;
using System.Collections.Generic;

namespace Lighting.Demos
{
    /// <summary>
    /// Simple implementation of the DemoSceneEnumerator using a enumerable list of scenes
    /// </summary>
    public abstract class DemoSceneStack : DemoSceneEnumerator
    {
        private IEnumerator<IScene> _scenes;

        protected abstract IEnumerable<IScene> CreateScenes();

        protected override IScene FirstScene()
        {
            _scenes = CreateScenes().GetEnumerator();
            return NextScene();
        }

        protected override IScene NextScene()
        {
            if (_scenes.MoveNext())
                return _scenes.Current;
            return null;
        }
    }
}
