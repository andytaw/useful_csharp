namespace Useful.TxnFramework.Core
{
    using System.Collections.Generic;

    public interface ITransaction<DtoIn, DtoOut>
    {
        IEnumerable<ValidationResult> Validate(DtoIn payload);

        DtoOut Execute(DtoIn payload);
    }
}
