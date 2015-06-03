namespace BankingKata
{
    public class Money
    {
        private readonly decimal m_Value;

        public Money(decimal value)
        {
            m_Value = value;
        }

        public override string ToString()
        {
            return "Money: " + m_Value;
        }

        protected bool Equals(Money other)
        {
            return m_Value == other.m_Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            return m_Value.GetHashCode();
        }
    }
}