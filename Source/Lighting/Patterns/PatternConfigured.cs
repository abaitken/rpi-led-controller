using System;
using System.Linq;

namespace Lighting.Patterns
{
    public class PatternConfigured : Pattern
    {
        private Color[] _colours;

        public Color[] Configured { get; set; } = new Color[0];

        public sealed override Color this[int index] => _colours[index];

        public override sealed void NextState(Random random)
        {
        }

        public override sealed void Reset(ILightingInformation information, Random random)
        {
            _colours = (from index in Enumerable.Range(0, information.LightCount)
                        select information[index].Color).ToArray();

            for (int i = 0; i < Math.Min(Configured.Length, information.LightCount); i++)
                _colours[i] = Configured[i];
        }
    }
}
