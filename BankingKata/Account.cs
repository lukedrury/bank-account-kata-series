using System;

namespace BankingKata
{
    public class Account
    {
        private readonly ILedger _transactionLog;

        public Account(ILedger transactionLog)
        {
            _transactionLog = transactionLog;
        }

        public Account() : this(new Ledger())
        {
        }

        public void Deposit(Money money)
        {
            var depositTransaction = new CreditEntry(money);
            _transactionLog.Record(depositTransaction);
        }

        public Money CalculateBalance()
        {
            return _transactionLog.Accept(new BalanceCalculatingVisitor(), new Money(0m));
        }

        public void Withdraw(Money money)
        {
            var debitEntry = new DebitEntry(money);
            _transactionLog.Record(debitEntry);
        }

        public void Print()
        {
            Console.Write("Balance: £" + CalculateBalance());
        }
    }
}