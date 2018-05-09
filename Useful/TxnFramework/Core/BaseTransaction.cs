namespace Useful.TxnFramework.Core
{
    public abstract class BaseTransaction<TIn, TOut>
    {
        public TIn Input { get; set; } = System.Activator.CreateInstance<TIn>();

        public TOut Output { get; set; }
    }
}
