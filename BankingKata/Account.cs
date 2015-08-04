using System;

namespace BankingKata
{
    public class Account
    {
        private readonly ILedger _transactionLog;
        private readonly IChequeNumberProvider _ChequeNumberProvider;


        public Account(ILedger transactionLog, IChequeNumberProvider chequeNumberProvider)
        {
            _transactionLog = transactionLog;
            _ChequeNumberProvider = chequeNumberProvider;
        }

        public Account()
            : this(new Ledger(), new ChequeNumberProvider())
        {
        }

        public void Deposit(DateTime transactionDate, Money money)
        {
            var depositTransaction = new CreditEntry(transactionDate, money);
            _transactionLog.Record(depositTransaction);
        }

        public Money CalculateBalance()
        {
            return _transactionLog.Accept(new BalanceCalculatingVisitor(), new Money(0m));
        }

        public void Withdraw(DateTime transactionDate, Money money)
        {
            var debitEntry = new DebitEntry(transactionDate, money);
            _transactionLog.Record(debitEntry);
        }

        public void PrintBalance(IPrinter printer)
        {
            var balance = CalculateBalance();
            printer.PrintBalance(balance);
        }

        public void PrintLastTransaction(IPrinter printer)
        {
            printer.PrintLastTransaction(_transactionLog);
        }

        public void WithdrawCheque(DateTime transactionDate, Money money)
        {
            var chequeNumberProvider = _ChequeNumberProvider;
            var chequeEntry = new ChequeEntry(transactionDate, money, chequeNumberProvider.Next());
            _transactionLog.Record(chequeEntry);
        }
    }
}