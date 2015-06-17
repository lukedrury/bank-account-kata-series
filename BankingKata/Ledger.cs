using System.Collections.Generic;
using System.Linq;

namespace BankingKata
{
    public class Ledger : ILedger
    {
        private readonly ICollection<ITransaction> _transactions = new List<ITransaction>();

        public void Record(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }

        public TArgument Accept<TArgument>(ITransactionVisitor<TArgument> visitor, TArgument initialValue)
        {
            return _transactions.Aggregate(initialValue, (argument, transaction) => visitor.Visit(transaction, argument));
        }
    }
}