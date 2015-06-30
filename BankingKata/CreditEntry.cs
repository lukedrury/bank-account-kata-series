using System;

namespace BankingKata
{
    public class CreditEntry : ITransaction
    {
        private readonly Money _amount;
        private readonly DateTime _date;

        public CreditEntry(Money amount, DateTime date)
        {
            _amount = amount;
            _date = date;
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

        public ITransaction Accept(IDateVisitor visitor)
        {
            return visitor.Visit(_date);
        }

        public override string ToString()
        {
            return _date + ", £" + _amount;
        }
    }
}