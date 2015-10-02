using System;

namespace BankingKata
{
    public class AccountWithOverdraft : IAccount
    {
        private readonly IAccount m_Account;
        private readonly IOverdraft m_Overdraft;

        public AccountWithOverdraft(IAccount account, IOverdraft overdraft)
        {
            m_Account = account;
            m_Overdraft = overdraft;
        }

        public void Withdraw(DebitEntry debitEntry)
        {
            m_Overdraft.Apply(m_Account, debitEntry);

            m_Account.Withdraw(debitEntry);
        }

        public void Deposit(DateTime transactionDate, Money money)
        {
            m_Account.Deposit(transactionDate, money);
        }

        public Money CalculateBalance()
        {
            return m_Account.CalculateBalance();
        }

        public void PrintBalance(IPrinter printer)
        {
            m_Account.PrintBalance(printer);
        }

        public void PrintLastTransaction(IPrinter printer)
        {
            m_Account.PrintLastTransaction(printer);
        }

    }
}