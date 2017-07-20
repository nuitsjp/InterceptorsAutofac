using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Dapper;

namespace TransactionInterceptorConsole
{
    public class DataAccessObject : IDataAccessObject
    {
        private readonly IConnectionHolder _connectionHolder;

        public DataAccessObject(IConnectionHolder connectionHolder)
        {
            _connectionHolder = connectionHolder;
        }

        public virtual string EnableTransaction()
        {
            var connection = _connectionHolder.Connection;
            var count = connection.Execute("update TestTable set Name = 'Updated' where id = 1");
            return connection.Query<TestTable>("select * from TestTable order by Id").FirstOrDefault()?.Name;
        }

        public virtual void ThrowException()
        {
            var connection = _connectionHolder.Connection;
            connection.Execute("update TestTable set Name = 'Updated2' where id = 1");
            throw new Exception();
        }

        public virtual bool UnableTransaction()
        {
            return _connectionHolder.Connection == null;
        }
    }
}
