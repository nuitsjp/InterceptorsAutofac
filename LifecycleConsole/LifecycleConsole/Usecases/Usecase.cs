using Autofac.Extras.DynamicProxy;
using LifecycleConsole.Common;
using LifecycleConsole.Daos;

namespace LifecycleConsole.Usecases
{
    [Intercept(typeof(TransactionInterceptor))]
    public class Usecase : IUsecase
    {
        private readonly IDao _dao;
        private readonly ITransactionService _transactionService;

        public Usecase(IDao dao, ITransactionService transactionService)
        {
            _dao = dao;
            _transactionService = transactionService;
        }

        public virtual void Register()
        {
            _transactionService.Write();
            _dao.Insert();
        }
    }
}
