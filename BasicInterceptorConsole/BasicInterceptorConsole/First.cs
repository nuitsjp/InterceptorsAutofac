using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;

namespace BasicInterceptorConsole
{
    [Intercept(typeof(CallLogger))]
    public class First
    {
        public virtual int GetValue()
        {
            // Do some calculation and return a value
            return 1;
        }
    }
}
