using Lighting.Scenes;
using System;

namespace Lighting.Demos
{
    public abstract class DemoSceneStack : Demo
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
            if (_currentScene.Step(controller, random) == SceneState.Complete)
                _currentScene = NextScene();

            if(_currentScene == null)
                return DemoState.Complete;

            return DemoState.InProgress;
        }

    }
}
