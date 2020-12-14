using System;

namespace Lighting.Patterns
{
    public class PatternRandomSolidColor : PatternSolidColor
    {
        public override void NextState(Random random)
        {
        }

        public override void Reset(ILightingController controller, Random random)
        {
            Color = Color.Random(random);
        }
    }
}
