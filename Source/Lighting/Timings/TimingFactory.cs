using Lighting.Dynamic;
using System;
using System.Reflection;

namespace Lighting.Timings
{
    public class TimingFactory : TypeFactory<ITiming>
    {
        public TimingFactory(TypeSource<ITiming> typeSource)
            : base(typeSource)
        {

        }
    }
}
