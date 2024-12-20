using Lighting.Palette;
using System;

namespace Lighting.Patterns
{
    public class PatternRandomSolidColor : PatternSolidColor
    {
        public override void NextState(Random random, IPalette palette)
        {
        }

        public override void Reset(ILightingInformation information, Random random, IPalette palette)
        {
            Color = palette.Random(random);
        }
    }
}
