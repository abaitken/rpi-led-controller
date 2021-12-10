using Lighting.Patterns;
using System;

namespace Lighting.Animations
{
    /// <summary>
    /// Represents the way in which a pattern is applied across the lighting strip
    /// </summary>
    public interface IAnimation
    {
        /// <summary>
        /// Starts the animation
        /// </summary>
        /// <param name="controller">Lighting controller</param>
        /// <param name="pattern">Pattern</param>
        /// <param name="random">Random</param>
        /// <returns>The remaining number of iterations</returns>
        int Begin(ILightingController controller, IPatternInformation pattern, Random random);

        /// <summary>
        /// Applies the next state of the animation
        /// </summary>
        /// <param name="controller">Lighting controller</param>
        /// <param name="pattern">Pattern</param>
        /// <param name="random">Random</param>
        /// <returns>Whether the animation is in progress or completed</returns>
        AnimationState Step(ILightingController controller, IPatternInformation pattern, Random random);
    }
}
