using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingKata
{
    public class Account
    {
        public void Deposit(Money money, DateTime dateTime)
        {
        }

        public Transaction LastTransaction()
        {
            return null;
        }

        public override string ToString()
        {
            string outstring = "";
            foreach (var transaction in m_TransactionLog)
            {
                outstring += transaction.ToString() + "\n";
            }
            return outstring;
        }
    }
}