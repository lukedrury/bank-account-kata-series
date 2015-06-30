using System;

namespace BankingKata
{
    public class DebitEntry : ITransaction
    {
        private readonly Money _amount;
        private readonly DateTime _date;

        public DebitEntry(Money amount, DateTime date)
        {
            _amount = amount;
            _date = date;
        }

        public Money ApplyTo(Money balance)
        {
            return balance - _amount;
        }

        public override bool Equals(object obj)
        {
            var transaction = (obj as DebitEntry);
            return transaction != null && _amount.Equals(transaction._amount);
        }

        public override string ToString()
        {
            return _date + ", £" + _amount;
        }
    }
}