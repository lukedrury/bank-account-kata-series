using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingKata
{
    public class Account
    {
        private readonly List<Transaction> m_TransactionLog = new List<Transaction>();

        public void Deposit(Money money, DateTime dateTime)
        {
            if (money <= new Money(0)) throw new InvalidDepositException();

            m_TransactionLog.Add(new Transaction(money, dateTime));
        }

        public Transaction LastTransaction()
        {
            return m_TransactionLog.Last();
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