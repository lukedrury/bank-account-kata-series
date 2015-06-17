namespace BankingKata
{
    public class BalanceCalculatingVisitor : ITransactionVisitor<Money>
    {
        public Money Visit(ITransaction currentTransaction, Money balance)
        {
            balance = currentTransaction.ApplyTo(balance);
            return balance;
        }
    }
}