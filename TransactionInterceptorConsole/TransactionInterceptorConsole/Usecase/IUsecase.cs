namespace TransactionInterceptorConsole
{
    public interface IUsecase
    {
        string EnableTransaction();

        void ThrowException();

        bool UnableTransaction();

    }
}