using LifecycleConsole.Common;

namespace LifecycleConsole.Daos
{
    public class Dao : IDao
    {
        private readonly ITransactionService _transactionService;

        public Dao(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public void Insert()
        {
            _transactionService.Write();
        }
    }
}
