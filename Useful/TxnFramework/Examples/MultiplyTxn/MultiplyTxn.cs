namespace Useful.TxnFramework.Examples.MultiplyTxn
{
    using System.Collections.Generic;
    using Useful.TxnFramework.Core;

    public class MultiplyTxn : BaseTransaction<MultiplyTxnDtoIn, MultiplyTxnDtoOut>, ITransaction
    {
        public void Execute()
        {
            this.Output = new MultiplyTxnDtoOut
            {
                Result = this.Input.A * this.Input.B
            };
        }

        public IEnumerable<ValidationResult> Validate()
        {
            return null;
        }
    }
}
