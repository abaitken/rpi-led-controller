using Lighting.Scenes;
using System;

namespace Lighting.Demos
{
    public abstract class DemoSceneEnumerator : Demo
    {
        private IScene _currentScene;

        public override sealed void Begin(ILightingController controller, Random random)
        {
            if (_currentScene == null)
                _currentScene = FirstScene();

            _currentScene.Begin(controller, random);
        }

        protected abstract IScene FirstScene();

        /// <summary>
        /// Gets the next scene
        /// </summary>
        /// <returns>Next scene or NULL if no more scenes are available</returns>
        protected abstract IScene NextScene();

        public override sealed DemoState Step(ILightingController controller, Random random)
        {
            if (_currentScene.Step(controller, random) == SceneState.InProgress)
                return DemoState.InProgress;

            _currentScene = NextScene();
            if (_currentScene == null)
                return DemoState.Complete;

            _currentScene.Begin(controller, random);
            return DemoState.InProgress;
        }
    }
}
