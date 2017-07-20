using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Castle.DynamicProxy;
using LifecycleConsole.Usecases;

namespace LifecycleConsole.Common
{
    public class TransactionInterceptor : IInterceptor
    {

        public TransactionInterceptor()
        {
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }
}
