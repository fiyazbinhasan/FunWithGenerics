using System;
using System.Collections.Generic;

namespace IoC
{
    public class Container
    {
        public Dictionary<Type, Type> Map { get; } = new();

        public ContainerBuilder For<T>()
        {
            return new ContainerBuilder(this, typeof(T));
        }

        public T Resolve<T>()
        {
            if (Map.TryGetValue(typeof(T), out var type))
            {
                return (T) CreateInstance(type);
            }

            throw new InvalidOperationException();
        }

        private static object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}