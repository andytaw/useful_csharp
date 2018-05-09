using System;
using System.Collections.Generic;
using System.Text;

namespace Useful.TxnFramework.Services
{
    public abstract class BaseService
    {
        protected readonly Core.TransactionFactory transactionFactory;
        protected readonly Core.TransactionManager transactionManager;

        public BaseService(
            Core.TransactionFactory transactionFactory,
            Core.TransactionManager transactionManager)
        {
            this.transactionFactory = transactionFactory;
            this.transactionManager = transactionManager;
        }
    }
}
