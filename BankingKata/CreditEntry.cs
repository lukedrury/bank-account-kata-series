namespace BankingKata
{
    public class CreditEntry : ITransaction
    {
        private readonly Money _amount;

        public CreditEntry(Money amount)
        {
            _amount = amount;
        }

        public override bool Equals(object obj)
        {
            var transaction = (obj as CreditEntry);
            return transaction != null && _amount.Equals(transaction._amount);
        }

        public Money ApplyTo(Money balance)
        {
            return balance + _amount;
        }

        public override string ToString()
        {
            return "£" + _amount;
        }
    }
}