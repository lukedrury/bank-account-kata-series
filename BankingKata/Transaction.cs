using System;

namespace BankingKata
{
    public class Transaction
    {
        private readonly Money m_Amount;
        private readonly DateTime m_DateTime;

        public Transaction(Money amount, DateTime dateTime)
        {
            m_Amount = amount;
            m_DateTime = dateTime;
        }

        protected bool Equals(Transaction other)
        {
            return Equals(m_Amount, other.m_Amount) && m_DateTime.Equals(other.m_DateTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Transaction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((m_Amount != null ? m_Amount.GetHashCode() : 0)*397) ^ m_DateTime.GetHashCode();
            }
        }

        public override string ToString()
        {
            return "Transaction: " + m_Amount + ", Date: " + m_DateTime;
        }
    }
}