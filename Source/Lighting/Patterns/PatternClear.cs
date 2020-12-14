using System;

namespace Lighting.Patterns
{
    public class PatternClear : PatternSolidColor
    {
        public override void Reset(ILightingController controller, Random random)
        {
            Color = Color.Black;
        }
    }
}
