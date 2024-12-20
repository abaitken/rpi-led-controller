using System;

namespace Lighting.Palette
{
    public abstract class Palette : IPalette
    {
        public abstract Color[] Colors { get; }

        public virtual Color Random(Random random)
        {
            return Colors[random.Next(Colors.Length)];
        }
    }
}
