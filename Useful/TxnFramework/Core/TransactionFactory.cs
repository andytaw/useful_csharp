using System;

namespace Useful.TxnFramework.Core
{
    public class TransactionFactory
    {
        public Txn Create<Txn>() where Txn: ITransaction
        {
            return Activator.CreateInstance<Txn>();
        }
    }
}
