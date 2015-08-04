using System;

namespace BankingKata
{
    public class ChequeEntry : ITransaction
    {
        public ChequeEntry(DateTime transactionDate, Money transactionAmount)
        {
        }

        public Money ApplyTo(Money balance)
        {
            return balance;
        }
    }
}