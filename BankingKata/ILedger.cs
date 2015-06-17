namespace BankingKata
{
    public interface ILedger
    {
        void Record(ITransaction transaction);
        TArgument Accept<TArgument>(ITransactionVisitor<TArgument> visitor, TArgument argument);
    }
}