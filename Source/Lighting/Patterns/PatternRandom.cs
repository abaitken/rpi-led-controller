using Lighting.Palette;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lighting.Patterns
{
    public class PatternRandom : Pattern
    {
        private List<Color> _colors;

        public override Color this[int index] => _colors[index];

        public override void NextState(Random random, IPalette palette)
        {
        }

        public override void Reset(ILightingInformation information, Random random, IPalette palette)
        {
            _colors = (from index in Enumerable.Range(0, information.LightCount)
                       select palette.Random(random)).ToList();
        }
    }
}
