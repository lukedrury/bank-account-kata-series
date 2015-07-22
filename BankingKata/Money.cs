namespace BankingKata
{
    public class Money
    {
        private readonly decimal _amount;

        public Money(decimal amount)
        {
            _amount = amount;
        }

        public override bool Equals(object @object)
        {
            var other = @object as Money;
            return other != null && _amount == other._amount;
        }

        public override string ToString()
        {
            return _amount.ToString("C");
        }

        public static Money operator +(Money @this, Money other)
        {
            var amount1 = @this._amount;
            var amount2 = other._amount;
            return new Money(amount1 + amount2);
        }

        public static Money operator -(Money @this, Money other)
        {
            var amount1 = @this._amount;
            var amount2 = other._amount;
            return new Money(amount1 - amount2);
        }
    }
}