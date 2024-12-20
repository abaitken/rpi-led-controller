using Lighting.Palette;
using Lighting.Scenes;
using System;

namespace Lighting.Demos
{
    public abstract class DemoSceneEnumerator : Demo
    {
        private IScene _currentScene;
        private IPalette _currentPalette;

        public override sealed void Begin(ILightingController controller, Random random)
        {
            if (_currentScene == null)
                _currentScene = FirstScene();

            if (_currentPalette == null)
                _currentPalette = new PaletteRandom();

            _currentScene.Begin(controller, random, _currentPalette);
        }

        protected abstract IScene FirstScene();

        /// <summary>
        /// Gets the next scene
        /// </summary>
        /// <returns>Next scene or NULL if no more scenes are available</returns>
        protected abstract IScene NextScene();

        public override sealed DemoState Step(ILightingController controller, Random random)
        {
            if (_currentScene.Step(controller, random, _currentPalette) == SceneState.InProgress)
                return DemoState.InProgress;

            _currentScene = NextScene();
            if (_currentScene == null)
                return DemoState.Complete;

            _currentScene.Begin(controller, random, _currentPalette);
            return DemoState.InProgress;
        }
    }
}
