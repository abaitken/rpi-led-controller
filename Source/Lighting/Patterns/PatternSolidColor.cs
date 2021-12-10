using System;

namespace Lighting.Patterns
{
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
