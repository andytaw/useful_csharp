namespace Useful.TxnFramework.Core
{
    using System.Collections.Generic;
    using System.Linq;

    public class TransactionManager
    {
        public TransactionManager()
        {

        }

        public DtoOut Execute<Txn, DtoIn, DtoOut>(Txn txn, DtoIn payload) where Txn : ITransaction<DtoIn, DtoOut>
        {
            // carry out authorisation

            // validate
            var validationResults = Validate(payload).Concat(txn.Validate(payload));

            if (validationResults.Any())
            {
                throw new TransactionValidationException(validationResults);
            }

            // logging

            // execute
            var retval =  txn.Execute(payload);

            // logging

            return retval;
        }

        private IEnumerable<ValidationResult> Validate(object payload)
        {
            // do annotation-based validation
            return new List<ValidationResult>();
        }
    }
}
