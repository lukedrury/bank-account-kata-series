using System;

namespace BankingKata
{
    public class ChequeEntry : ITransaction
    {
        private readonly DateTime transactionDate;
        private readonly Money transactionAmount;

        public ChequeEntry(DateTime transactionDate, Money transactionAmount)
        {
            this.transactionDate = transactionDate;
            this.transactionAmount = transactionAmount;
        }

        public override bool Equals(object obj)
        {
            var transaction = (obj as ChequeEntry);
            return transaction != null && transactionAmount.Equals(transaction.transactionAmount);
        }

        public Money ApplyTo(Money balance)
        {
            return balance - transactionAmount;
        }
        
        public override string ToString()
        {
            return string.Format("CHQ {0} ({1})", transactionDate.ToString("dd MMM yyyy"), transactionAmount);
        }
    }
}