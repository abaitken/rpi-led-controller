using System;

namespace Lighting.Patterns
{
    public class PatternRandomSolidColorChanging : PatternSolidColor
    {
        public override void NextState(Random random)
        {
            Color = Color.Random(random);
        }

        public override void Reset(ILightingInformation information, Random random)
        {
            NextState(random);
        }
    }
}
