using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;

namespace BasicInterceptorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<First>().EnableClassInterceptors();
            builder.Register(c => new CallLogger(Console.Out));
            var container = builder.Build();

            var first = container.Resolve<First>();
            first.GetValue();
            Console.ReadLine();
        }
    }
}
