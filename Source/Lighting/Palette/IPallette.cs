using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lighting.Palette
{
    /// <summary>
    /// Represents a colour theme
    /// </summary>
    public interface IPalette
    {
        /// <summary>
        /// Colours present in the palette
        /// </summary>
        /// <remarks>Colors could be empty. In which case the full colour spectrum is available.</remarks>
        public Color[] Colors { get; }

        /// <summary>
        /// Pick a colour at random from the palette
        /// </summary>
        /// <param name="random">Random seed</param>
        /// <returns>Color</returns>
        Color Random(Random random);
    }

    
}
