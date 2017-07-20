using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;

namespace TransactionInterceptorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionManager.Settings = ConfigurationManager.ConnectionStrings["DFSConnection"];

            var builder = new ContainerBuilder();
            builder.RegisterType<ConnectionHolder>().As<IConnectionHolder>().SingleInstance();
            builder.RegisterType<TransactionManager>();

            builder.RegisterType<Usecase>().As<IUsecase>().EnableClassInterceptors();
            builder.RegisterType<DataAccessObject>().As<IDataAccessObject>();

            var container = builder.Build();

            var usecase = container.Resolve<IUsecase>();

            Console.WriteLine($"dataAccessObject.EnableTransaction():{usecase.EnableTransaction()}");

            try
            {
                usecase.ThrowException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            System.GC.Collect();
            
            Console.WriteLine($"dataAccessObject.UnableTransaction():{usecase.UnableTransaction()}");


            Console.ReadLine();
        }
    }
}
