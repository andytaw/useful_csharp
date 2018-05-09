namespace Useful.TxnFramework.Core
{
    using System.Collections.Generic;
    using System.Linq;

    public class TransactionValidationException: System.Exception
    {
        private readonly IEnumerable<ValidationResult> validationResults;

        public TransactionValidationException(IEnumerable<ValidationResult> validationResults)
        {
            this.validationResults = validationResults;
        }

        public override string ToString()
        {
            return base.ToString() +
                System.Environment.NewLine +
                string.Join(System.Environment.NewLine, validationResults.Select(x => x.ToString()));
        }
    }
}
