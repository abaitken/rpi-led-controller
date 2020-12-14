using Lighting.Dynamic;
using System;
using System.Reflection;

namespace Lighting.Patterns
{
    public class PatternFactory : TypeFactory<IPattern>
    {
        public PatternFactory(TypeSource<IPattern> typeSource, Random random)
            : base(typeSource, random)
        {

        }
    }
}
