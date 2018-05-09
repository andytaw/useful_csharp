namespace Useful.TxnFramework.Core
{
    using System.Collections.Generic;
    using System.Linq;

    public class TransactionManager
    {
        public TransactionManager()
        {

        }

        public void Execute<Txn>(Txn txn) where Txn : ITransaction
        {
            // carry out authorisation

            // validate
            var validationResults = txn.Validate();

            if (validationResults.Any())
            {
                throw new TransactionValidationException(validationResults);
            }

            // logging

            // execute
            txn.Execute();

            // logging
        }
    }
}
