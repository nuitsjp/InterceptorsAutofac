using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Castle.DynamicProxy;

namespace TransactionInterceptorConsole
{
    public class TransactionManager : IInterceptor
    {
        public static ConnectionStringSettings Settings { get; set; }
        
        private readonly IConnectionHolder _connectionHolder;

        public TransactionManager(IConnectionHolder connectionHolder)
        {
            _connectionHolder = connectionHolder;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.GetCustomAttribute<TransactionAttribute>() == null)
            {
                invocation.Proceed();
            }
            else
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.ProviderName);
                using (var transactionScope = new TransactionScope())
                using (var connection = factory.CreateConnection())
                {
                    connection.ConnectionString = Settings.ConnectionString;
                    connection.Open();

                    _connectionHolder.Connection = connection;

                    invocation.Proceed();
                    transactionScope.Complete();
                }
            }
        }
    }
}
