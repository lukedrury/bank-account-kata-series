using System;

namespace BankingKata
{
    public class ConsolePrinter : IPrinter
    {
        public void PrintBalance(Money balance)
        {
            Console.WriteLine("Balance: {0}", balance);
        }

        public void PrintLastTransaction(ILedger ledger)
        {
            var lastTransaction = ledger.Accept(new LastTransactionVisitor(), null);
            Console.WriteLine("Last transaction: {0}", lastTransaction);
        }

        public ITransaction Visit(ITransaction currentTransaction, ITransaction argument)
        {
            return currentTransaction;
        }

        private class LastTransactionVisitor : ITransactionVisitor<ITransaction>
        {
            public ITransaction Visit(ITransaction currentTransaction, ITransaction argument)
            {
                return currentTransaction;
            }
        }
    }
}