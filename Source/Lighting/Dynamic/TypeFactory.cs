using System;
using System.Collections.Generic;
using System.Linq;

namespace Lighting.Dynamic
{
    public abstract class TypeFactory<T>
    {
        private readonly List<Type> _types;

        public TypeFactory(TypeSource<T> typeSource)
        {
            var types = typeSource.GetTypes();

            _types = types.ToList();
        }

        public T GenerateRandom(Random random)
        {
            var type = _types[random.Next(_types.Count)];

            return (T)Activator.CreateInstance(type);
        }
    }
}
