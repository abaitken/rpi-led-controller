using Lighting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LightingConsole
{
    class ConsoleController : ILightingController
    {
        private List<Color> _colors;

        public ConsoleController()
        {
            _colors = (from index in Enumerable.Range(0, LightCount)
                       select Color.Black).ToList();
        }

        struct Light : ILight
        {
            private readonly int _index;
            private readonly List<Color> _colors;

            public Light(List<Color> _colors, int index)
            {
                _index = index;
                this._colors = _colors;
            }

            public Color Color
            {
                get => _colors[_index];
                set => _colors[_index] = value;
            }
        }

        public ILight this[int index] => new Light(_colors, index);

        public int LightCount => Console.BufferWidth - 2;

        public byte DefaultBrightness => 150;

        public byte Brightness { get; set; }

        char[] _chars = new[] { '*', '#', '@', '+' };
        Random random = new Random();

        public void Update()
        {
            Console.CursorTop = Console.CursorTop == 0 ? Console.CursorTop : Console.CursorTop - 1;

            for (int i = 0; i < _colors.Count; i++)
            {
                var color = _colors[i];
                if (color == Color.Black)
                    Console.Write(' ');
                else
                    Console.Write(_chars[random.Next(_chars.Length)]);
            }
            Console.WriteLine();
        }
    }
}