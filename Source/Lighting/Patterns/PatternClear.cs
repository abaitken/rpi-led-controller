using Lighting.Palette;
using System;

namespace Lighting.Patterns
{
    public class PatternClear : PatternSolidColor
    {
        public override void Reset(ILightingInformation information, Random random, IPalette palette)
        {
            Color = Color.Black;
        }
    }
}
