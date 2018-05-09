namespace Useful.TxnFramework.Services
{
    public class Calculator: BaseService
    {

        public Calculator(
            Core.TransactionFactory transactionFactory,
            Core.TransactionManager transactionManager)
            :base(transactionFactory, transactionManager)
        {
        }

        public int Add(int a, int b)
        {
            var txn = transactionFactory.Create<Examples.AddTxn.AddTxn>();

            txn.Input.A = a;
            txn.Input.B = b;

            transactionManager.Execute(txn);

            return txn.Output.Result;
        }

        public int Multiply(int a, int b)
        {
            var txn = transactionFactory.Create<Examples.MultiplyTxn.MultiplyTxn>();

            txn.Input.A = a;
            txn.Input.B = b;

            transactionManager.Execute(txn);

            return txn.Output.Result;
        }
    }
}
