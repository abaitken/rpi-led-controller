using System;

namespace Lighting.Patterns
{
    /// <summary>
    /// Pattern which sets all lights to the same colour
    /// </summary>
    public class PatternSolidColor : Pattern
    {
        public Color Color { get; set; }

        public sealed override Color this[int index] => Color;

        public override void NextState(Random random)
        {
        }

        public override void Reset(ILightingInformation information, Random random)
        {
        }
    }
}
