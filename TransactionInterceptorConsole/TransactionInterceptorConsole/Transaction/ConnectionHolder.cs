using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionInterceptorConsole
{
    public class ConnectionHolder : IConnectionHolder
    {
        private WeakReference<IDbConnection> _connection;

        public IDbConnection Connection
        {
            get
            {
                IDbConnection value;
                if (_connection == null || !_connection.TryGetTarget(out value))
                {
                    value = null;
                    _connection = null;
                }
                return value; 
                
            }
            set => _connection = new WeakReference<IDbConnection>(value);
        }
    }
}
