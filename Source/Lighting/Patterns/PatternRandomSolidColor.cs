using System;

namespace Lighting.Patterns
{
    public class PatternRandomSolidColor : PatternSolidColor
    {
        public override void NextState(Random random)
        {
        }

        public override void Reset(ILightingInformation information, Random random)
        {
            Color = Color.Random(random);
        }
    }
}
