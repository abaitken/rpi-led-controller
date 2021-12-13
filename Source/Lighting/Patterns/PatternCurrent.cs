using System;
using System.Linq;

namespace Lighting.Patterns
{
    /// <summary>
    /// Stores the current pattern
    /// </summary>
    public class PatternCurrent : Pattern
    {
        private Color[] _colours;

        public override Color this[int index] => _colours[index];

        public override void NextState(Random random)
        {

        }

        public override void Reset(ILightingInformation information, Random random)
        {
            _colours = (from index in Enumerable.Range(0, information.LightCount)
                        select information[index].Color).ToArray();
        }
    }
}
