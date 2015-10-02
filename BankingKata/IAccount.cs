using System;

namespace BankingKata
{
    public interface IAccount
    {
        void Deposit(DateTime transactionDate, Money money);
        Money CalculateBalance();
        void Withdraw(DebitEntry debitEntry);
        void PrintBalance(IPrinter printer);
        void PrintLastTransaction(IPrinter printer);
    }
}