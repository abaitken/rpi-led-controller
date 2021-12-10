using System;

namespace Lighting.Demos
{
    /// <summary>
    /// Represents a number of scenes
    /// </summary>
    public interface IDemo
    {
        /// <summary>
        /// Starts the demo
        /// </summary>
        /// <param name="controller">Lighting controller</param>
        /// <param name="random">Random</param>
        void Begin(ILightingController controller, Random random);

        /// <summary>
        /// Applies the next state of the demo
        /// </summary>
        /// <param name="controller">Lighting controller</param>
        /// <param name="random">Random</param>
        /// <returns>Current state of the demo, whether it has finished or not</returns>
        DemoState Step(ILightingController controller, Random random);
    }
}
