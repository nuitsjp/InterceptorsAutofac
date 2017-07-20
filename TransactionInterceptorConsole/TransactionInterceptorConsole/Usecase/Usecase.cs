using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;

namespace TransactionInterceptorConsole
{
    [Intercept(typeof(TransactionManager))]
    public class Usecase : IUsecase
    {
        private readonly IDataAccessObject _dataAccessObject;

        public Usecase(IDataAccessObject dataAccessObject)
        {
            _dataAccessObject = dataAccessObject;
        }

        [Transaction]
        public virtual string EnableTransaction()
        {
            return _dataAccessObject.EnableTransaction();
        }

        [Transaction]
        public virtual void ThrowException()
        {
            _dataAccessObject.ThrowException();
        }

        public virtual bool UnableTransaction()
        {
            return _dataAccessObject.UnableTransaction();
        }
    }
}
