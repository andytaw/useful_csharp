namespace Useful.TxnFramework.Core
{
    using System.Collections.Generic;

    public interface ITransaction
    {
        IEnumerable<ValidationResult> Validate();

        void Execute();
    }
}
