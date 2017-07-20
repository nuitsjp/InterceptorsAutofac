using System.Data;

namespace TransactionInterceptorConsole
{
    public interface IConnectionHolder
    {
        IDbConnection Connection { get; set; }
    }
}