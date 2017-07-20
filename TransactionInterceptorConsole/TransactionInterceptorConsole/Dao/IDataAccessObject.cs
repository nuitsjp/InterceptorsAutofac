using Autofac.Extras.DynamicProxy;

namespace TransactionInterceptorConsole
{
    //[Intercept(typeof(TransactionManager))]
    public interface IDataAccessObject
    {
        string EnableTransaction();

        void ThrowException();

        bool UnableTransaction();
    }
}