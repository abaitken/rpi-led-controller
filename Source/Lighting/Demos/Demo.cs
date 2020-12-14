using System;

namespace Lighting.Demos
{
    public abstract class Demo : IDemo
    {
        public abstract void Begin(ILightingController controller, Random random);
        public abstract DemoState Step(ILightingController controller, Random random);
    }
}
