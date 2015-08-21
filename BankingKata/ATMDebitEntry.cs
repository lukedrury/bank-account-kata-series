using System;

namespace BankingKata
{
    public class ATMDebitEntry : DebitEntry
    {
        public ATMDebitEntry(DateTime transactionDate, Money transactionAmount) : base(transactionDate, transactionAmount)
        {
        }

        public override string ToString()
        {
            return string.Format("ATM {0}", base.ToString());
        }
    }
}