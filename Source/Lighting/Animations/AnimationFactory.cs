using Lighting.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lighting.Animations
{
    public class AnimationFactory : TypeFactory<IAnimation>
    {
        public AnimationFactory(TypeSource<IAnimation> typeSource)
            : base(typeSource)
        {

        }
    }
}
