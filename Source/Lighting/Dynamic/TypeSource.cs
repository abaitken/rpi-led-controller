using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lighting.Dynamic
{
    public class TypeSource<T>
    {
        private readonly List<Assembly> _assemblies;
        private readonly List<Type> _exclude;
        private readonly List<Type> _include;

        private TypeSource()
        {
            _assemblies = new List<Assembly>();
            _exclude = new List<Type>();
            _include = new List<Type>();
        }

        public static TypeSource<T> From(params Assembly[] assemblies)
        {
            return new TypeSource<T>().Include(assemblies);
        }

        internal static TypeSource<T> FromThisAssembly()
        {
            return From(Assembly.GetExecutingAssembly());
        }

        public TypeSource<T> Include(params Assembly[] assemblies)
        {
            return Include(assemblies.AsEnumerable());
        }

        public TypeSource<T> Include(IEnumerable<Assembly> assemblies)
        {
            _assemblies.AddRange(assemblies);
            return this;
        }

        public TypeSource<T> Exclude(params Type[] types)
        {
            return Exclude(types.AsEnumerable());
        }

        public TypeSource<T> Exclude(IEnumerable<Type> types)
        {
            _exclude.AddRange(types);
            return this;
        }

        public TypeSource<T> Exclude<TImpl>()
            where TImpl : T
        {
            return Exclude(typeof(TImpl));
        }

        private IEnumerable<Type> Discover(Assembly assembly)
        {
            return from item in assembly.GetTypes()
                   where IsConstructable(item)
                   select item;
        }

        private IEnumerable<Type> DiscoverAll()
        {
            return from assembly in _assemblies
                   from item in Discover(assembly)
                   select item;
        }

        public IEnumerable<Type> GetTypes()
        {
            return DiscoverAll().Concat(_include).Distinct();
        }

        private bool IsConstructable(Type item)
        {
            // Not excluded
            if (_exclude.Contains(item))
                return false;

            // Not abstract
            if (item.IsAbstract)
                return false;

            // Implements the desired base type
            if (!typeof(T).IsAssignableFrom(item))
                return false;

            // Has an empty constructor
            if (!item.GetConstructors().Any(i => i.GetParameters().Length == 0))
                return false;

            return true;
        }
    }
}
