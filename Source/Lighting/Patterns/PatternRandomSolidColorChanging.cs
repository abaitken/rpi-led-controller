using Lighting.Palette;
using System;

namespace Lighting.Patterns
{
    public class PatternRandomSolidColorChanging : PatternSolidColor
    {
        private Color PickColor(Random random, IPalette palette)
        {
            // If there are no colours, pick anything
            if (palette.Colors.Length == 0)
                return palette.Random(random);

            // If there is only one, pick the first one
            if (palette.Colors.Length == 1)
                return palette.Colors[0];

            // If there are two, switch between them
            if (palette.Colors.Length == 2)
            {
                var index = (palette.Colors[0] == Color) ? 1 : 0;

                return palette.Colors[index];
            }

            // TODO : Pick again if colour is same as before
            return palette.Random(random);
        }

        public override void NextState(Random random, IPalette palette)
        {
            Color = PickColor(random, palette);
        }

        public override void Reset(ILightingInformation information, Random random, IPalette palette)
        {
            NextState(random, palette);
        }
    }
}
