using System;

namespace Lighting.Demos
{
    public interface IDemo
    {
        void Begin(ILightingController controller, Random random);
        DemoState Step(ILightingController controller, Random random);
    }
}
