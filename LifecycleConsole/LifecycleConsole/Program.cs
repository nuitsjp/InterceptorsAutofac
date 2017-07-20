using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using LifecycleConsole.Common;
using LifecycleConsole.Daos;
using LifecycleConsole.Usecases;

namespace LifecycleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TransactionService>().As<ITransactionService>().InstancePerLifetimeScope();
            builder.RegisterType<TransactionInterceptor>();
            builder.RegisterType<Dao>().As<IDao>();
            builder.RegisterType<Usecase>().As<IUsecase>().EnableClassInterceptors();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var usecase = scope.Resolve<IUsecase>();
                usecase.Register();
            }

            using (var scope = container.BeginLifetimeScope())
            {
                var usecase = scope.Resolve<IUsecase>();
                usecase.Register();
            }
        }
    }
}
