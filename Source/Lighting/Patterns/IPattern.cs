using Lighting.Palette;
using System;

namespace Lighting.Patterns
{
    /// <summary>
    /// Represents colours across a lighting strip
    /// </summary>
    public interface IPattern : IPatternInformation
    {
        /// <summary>
        /// Resets the pattern to its initial state
        /// </summary>
        /// <param name="information">Lighting information</param>
        /// <param name="random">Random</param>
        /// /// <param name="palette">Palette</param>
        void Reset(ILightingInformation information, Random random, IPalette palette);

        /// <summary>
        /// Sets the pattern to the next state
        /// </summary>
        /// <param name="random">Random</param>
        /// /// <param name="palette">Palette</param>
        void NextState(Random random, IPalette palette);
    }
}
