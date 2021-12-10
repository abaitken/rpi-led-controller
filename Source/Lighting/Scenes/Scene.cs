using System;

namespace Lighting.Scenes
{
    public abstract class Scene : IScene
    {
        public abstract void Begin(ILightingController controller, Random random);
        public abstract SceneState Step(ILightingController controller, Random random);
    }
}
