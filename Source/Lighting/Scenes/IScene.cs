using Lighting.Palette;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lighting.Scenes
{
    /// <summary>
    /// Represents a lighting scene
    /// </summary>
    public interface IScene
    {
        /// <summary>
        /// Starts the scene
        /// </summary>
        /// <param name="controller">Controller</param>
        /// <param name="random">Random</param>
        /// <param name="palette">Palette</param>
        void Begin(ILightingController controller, Random random, IPalette palette);

        /// <summary>
        /// Applies the next state of the scene
        /// </summary>
        /// <param name="controller">Lighting controller</param>
        /// <param name="random">Random</param>
        /// <param name="palette">Palette</param>
        /// <returns>Current state of the scene and whether it has finished or not</returns>
        SceneState Step(ILightingController controller, Random random, IPalette palette);
    }
}
