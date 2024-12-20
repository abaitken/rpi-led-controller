using Lighting.Palette;
using System;

namespace Lighting.Patterns
{
    /// <summary>
    /// Pattern which sets all lights to the same colour
    /// </summary>
    public class PatternSolidColor : Pattern
    {
        public Color Color { get; set; } = Color.White;

        public sealed override Color this[int index] => Color;

        public override void NextState(Random random, IPalette palette)
        {
        }

        public override void Reset(ILightingInformation information, Random random, IPalette palette)
        {
        }
    }
}
