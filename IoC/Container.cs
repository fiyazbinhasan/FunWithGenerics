using System;
using System.Collections.Generic;

namespace IoC
{
    public partial class Container
    {
        public Dictionary<Type, Type> Map { get; set; } = new();

        public ContainerBuilder For<T>()
        {
            return new ContainerBuilder(this, typeof(T));
        }

        public T Resolve<T>()
        {
            if(Map.TryGetValue(typeof(T), out var type))
            {
                return (T) CreateInstance(type);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}