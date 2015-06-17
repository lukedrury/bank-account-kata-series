namespace BankingKata
{
    public interface ITransactionVisitor<TArgument>
    {
        TArgument Visit(ITransaction currentTransaction, TArgument argument);
    }
}