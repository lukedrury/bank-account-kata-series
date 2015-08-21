using System;

namespace BankingKata
{
    public abstract class DebitEntry : ITransaction
    {
        private readonly DateTime _transactionDate;
        private readonly Money _transactionAmount;

        protected DebitEntry(DateTime transactionDate, Money transactionAmount)
        {
            _transactionDate = transactionDate;
            _transactionAmount = transactionAmount;
        }

        public Money ApplyTo(Money balance)
        {
            return balance - _transactionAmount;
        }

        public override bool Equals(object obj)
        {
            var transaction = (obj as DebitEntry);
            return transaction != null && _transactionAmount.Equals(transaction._transactionAmount);
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", _transactionDate.ToString("dd MMM yyyy"), _transactionAmount);
        }
    }
}