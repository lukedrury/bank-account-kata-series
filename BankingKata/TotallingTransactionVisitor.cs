namespace BankingKata
{
    public class TotallingTransactionVisitor
    {
        public Money Visit(ITransaction transaction, Money balance)
        {
            return transaction.ApplyTo(balance);
        }
    }
}