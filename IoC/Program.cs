using System;
using System.Collections.Generic;

namespace IoC
{
    static class Program
    {
        static void Main(string[] args)
        {
            var ioc = new Container();
            ioc.For<ILogger>().Use<Logger>();

            var logger = ioc.Resolve<ILogger>();

            Console.WriteLine(logger.GetType() == typeof(Logger));
        }
    }
}
