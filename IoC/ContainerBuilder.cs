using System;

namespace IoC
{
    public class ContainerBuilder
    {
        private readonly Container _container;
        private readonly Type _sourceType;
    
        public ContainerBuilder(Container container, Type sourceType)
        {
            _container = container;
            _sourceType = sourceType;
        }
    
        public void Use<T>()
        {
            _container.Map.Add(_sourceType, typeof(T));
        }
    }
}