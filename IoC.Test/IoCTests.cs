using System;
using Xunit;
using IoC;

namespace IoC.Test
{
    public class IoCTests
    {
        [Fact]
        public void Can_Resolve_Types()
        {
            var ioc = new Container();
            ioc.For<ILogger>().Use<Logger>();

            var logger = ioc.Resolve<ILogger>();

            Assert.Equal(typeof(Logger), logger.GetType());
        }
    }
}
