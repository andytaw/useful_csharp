namespace Useful.TxnFramework.Examples.AddTxn
{
    using System.Collections.Generic;
    using Useful.TxnFramework.Core;

    public class AddTxn : ITransaction<AddTxnDtoIn, AddTxnDtoOut>
    {
        public AddTxnDtoOut Execute(AddTxnDtoIn payload)
        {
            return new AddTxnDtoOut
            {
                Result = payload.A + payload.B
            };
        }

        public IEnumerable<ValidationResult> Validate(AddTxnDtoIn payload)
        {
            return null;
        }
    }
}
