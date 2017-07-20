using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionInterceptorConsole
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class TransactionAttribute : Attribute
    {
    }
}
