using Lighting.Demos;
using System;

namespace LightingConsole
{
    internal class App
    {
        public App()
        {
        }

        internal void Run(string[] args)
        {
            var controller = new ConsoleController();
            var random = new Random();
            while (true)
            {
                var demo = new DemoRandom();
                demo.Begin(controller, random);

                while (demo.Step(controller, random) == DemoState.InProgress) ;
            }
        }
    }
}