using System;

namespace Lighting.Palette
{
    public class PaletteRandom : Palette
    {
        public override Color[] Colors => new Color[0];

        public override Color Random(Random random)
        {
            return Color.Random(random);
        }
    }
}
