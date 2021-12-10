using System;

namespace Lighting.Patterns
{
    /// <summary>
    /// Represents colours across a lighting strip
    /// </summary>
    public interface IPattern
    {
        /// <summary>
        /// Gets the current colour for the given index
        /// </summary>
        /// <param name="index">Light index</param>
        /// <returns>The current colour</returns>
        Color this[int index] { get; }

        /// <summary>
        /// Resets the pattern to its initial state
        /// </summary>
        /// <param name="information">Lighting information</param>
        /// <param name="random">Random</param>
        void Reset(ILightingInformation information, Random random);

        /// <summary>
        /// Sets the pattern to the next state
        /// </summary>
        /// <param name="random">Random</param>
        void NextState(Random random);
    }
}
