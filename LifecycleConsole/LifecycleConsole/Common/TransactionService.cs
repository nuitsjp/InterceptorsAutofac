using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LifecycleConsole.Common
{
    public class TransactionService : ITransactionService
    {
        private static int count = 0;

        public TransactionService()
        {
            count++;
        }
        
        public void Write([CallerMemberName]string name = null)
        {
            Console.WriteLine($"Caller:{name} Count:{count}");
        }
    }
}
