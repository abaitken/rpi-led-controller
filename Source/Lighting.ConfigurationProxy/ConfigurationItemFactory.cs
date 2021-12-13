using Lighting.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lighting.ConfigurationProxy
{
    public class ConfigurationItemFactory
    {
        private readonly TypeSource<IDemonstrationProxy> _demonstrations;

        public ConfigurationItemFactory()
        {
            _demonstrations = TypeSource<IDemonstrationProxy>.From(Assembly.GetExecutingAssembly());
        }
    }
}
