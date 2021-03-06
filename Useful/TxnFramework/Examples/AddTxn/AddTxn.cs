﻿namespace Useful.TxnFramework.Examples.AddTxn
{
    using System.Collections.Generic;
    using Useful.TxnFramework.Core;

    public class AddTxn : BaseTransaction<AddTxnDtoIn, AddTxnDtoOut>, ITransaction
    {
        public void Execute()
        {
            this.Output = new AddTxnDtoOut
            {
                Result = this.Input.A + this.Input.B
            };
        }

        public IEnumerable<ValidationResult> Validate()
        {
            return null;
        }
    }
}
