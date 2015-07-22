using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    public class MoneyTests
    {
        [Test]
        public void TwoMoniesWithTheSameValueAreEqual()
        {
            const decimal amountOfMoney = 3m;
            var money1 = new Money(amountOfMoney);
            var money2 = new Money(amountOfMoney);
            Assert.That(money1,Is.EqualTo(money2));
        }

        [Test]
        public void TwoMoniesWithDifferentValuesAreNotEqual()
        {
            Money money1 = new Money(3m);
            Money money2 = new Money(5m);

            Assert.That(money1, Is.Not.EqualTo(money2));
        }

        [Test]
        public void MoneyIsntEqualToHats()
        {
            var money = new Money(3m);
            object hat = new {shape = "bowler"};
            Assert.That(money.Equals(hat), Is.False);
        }

        [Test]
        public void ToStringConvertsTheDecimalValueToAString()
        {
            Assert.That(new Money(4m).ToString(), Is.EqualTo("£4.00"));
        }
    }
}
