using Lighting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LightingConsole
{
    class ConsoleController : ILightingController
    {
        private readonly List<Color> _lights;
        private readonly char[] _chars = new[] { '*', '#', '@', '+' };
        private readonly Random random = new Random();

        public ConsoleController()
        {
            _lights = (from index in Enumerable.Range(0, LightCount)
                       select Color.Black).ToList();
        }

        struct Light : ILight
        {
            private readonly int _index;
            private readonly List<Color> _lights;

            public Light(List<Color> lights, int index)
            {
                _index = index;
                _lights = lights;
            }

            public Color Color
            {
                get => _lights[_index];
                set => _lights[_index] = value;
            }
        }

        public ILight this[int index] => new Light(_lights, index);

        public int LightCount => Console.BufferWidth - 1;

        public byte DefaultBrightness => 150;

        public byte Brightness { get; set; }

        public void Update()
        {
            Console.CursorTop = Console.CursorTop == 0 ? Console.CursorTop : Console.CursorTop - 1;

            for (int i = 0; i < _lights.Count; i++)
            {
                var item = _lights[i];
                Console.ForegroundColor = ClosestConsoleColor(item);
                Console.Write("@");
            }
            Console.WriteLine();
        }

        private readonly Tuple<Color, ConsoleColor>[] _mappings = new[]
            {
                new Tuple<Color, ConsoleColor>(Color.DarkBlue, ConsoleColor.DarkBlue),
                new Tuple<Color, ConsoleColor>(Color.DarkGreen, ConsoleColor.DarkGreen),
                new Tuple<Color, ConsoleColor>(Color.DarkCyan, ConsoleColor.DarkCyan),
                new Tuple<Color, ConsoleColor>(Color.DarkRed, ConsoleColor.DarkRed),
                new Tuple<Color, ConsoleColor>(Color.DarkMagenta, ConsoleColor.DarkMagenta),
                new Tuple<Color, ConsoleColor>(new Color(155, 135, 12), ConsoleColor.DarkYellow),
                new Tuple<Color, ConsoleColor>(Color.Gray, ConsoleColor.Gray),
                new Tuple<Color, ConsoleColor>(Color.DarkGray, ConsoleColor.DarkGray),
                new Tuple<Color, ConsoleColor>(Color.Blue, ConsoleColor.Blue),
                new Tuple<Color, ConsoleColor>(Color.Green, ConsoleColor.Green),
                new Tuple<Color, ConsoleColor>(Color.Cyan, ConsoleColor.Cyan),
                new Tuple<Color, ConsoleColor>(Color.Red, ConsoleColor.Red),
                new Tuple<Color, ConsoleColor>(Color.Magenta, ConsoleColor.Magenta),
                new Tuple<Color, ConsoleColor>(Color.Yellow, ConsoleColor.Yellow),
                new Tuple<Color, ConsoleColor>(Color.White, ConsoleColor.White)
            };

        private ConsoleColor ClosestConsoleColor(Color color)
        {
            if (color == Color.Black)
                return ConsoleColor.Black;

            var diffs = from item in _mappings
                        let match = item.Item1
                        let score = Math.Abs(match.Distance(color))
                        orderby score ascending
                        select new { result = item.Item2, score };

            return diffs.First().result;
        }
    }
}