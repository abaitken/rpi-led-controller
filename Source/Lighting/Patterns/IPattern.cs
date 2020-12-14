using System;

namespace Lighting.Patterns
{
    public interface IPattern
    {
        Color this[int index] { get; }
        void Reset(ILightingController controller, Random random);
        void NextState(Random random);
    }
}
