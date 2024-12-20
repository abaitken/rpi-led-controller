using Lighting.Palette;
using System;

namespace Lighting.Patterns
{
    public abstract class Pattern : IPattern
    {
        public abstract Color this[int index] { get; }
        public abstract void NextState(Random random, IPalette palette);
        public abstract void Reset(ILightingInformation information, Random random, IPalette palette);
    }
}
