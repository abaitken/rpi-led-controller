using System;
using System.Collections.Generic;
using System.Linq;

namespace Lighting.Dynamic
{
    public abstract class TypeFactory<T>
    {
        private readonly List<Type> _types;
        private readonly Random _random;

        public TypeFactory(TypeSource<T> typeSource, Random random)
        {
            var types = typeSource.GetTypes();

            _types = types.ToList();
            _random = random;
        }

        public T GenerateRandom()
        {
            var type = _types[_random.Next(_types.Count)];

            return (T)Activator.CreateInstance(type);
        }
    }
}
