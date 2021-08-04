using System;
using System.Collections.Generic;

namespace IoC
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _map = new();

        public ContainerBuilder For<T>()
        {
            return new ContainerBuilder(this, typeof(T));
        }

        public T Resolve<T>()
        {
            if(_map.TryGetValue(typeof(T), out var type))
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

        public class ContainerBuilder
        {
            private readonly Container _container;
            private readonly Type _sourceType;

            public ContainerBuilder(Container container, Type sourceType)
            {
                _container = container;
                _sourceType = sourceType;
            }

            public ContainerBuilder Use<T>()
            {
                _container._map.Add(_sourceType, typeof(T));
                return this;
            }
        }
    }

    public class Logger : ILogger
    {
    }

    public interface ILogger
    {
    }
}