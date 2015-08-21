using BankingKata;
using NUnit.Framework;
using System;

namespace BankingKataTests
{
    [TestFixture]
    public class AccountAcceptanceTests
    {
        [Test]
        public void DepositingCashIncreasesTheAccountBalance()
        {
            var account = new Account();

            account.Deposit(DateTime.Now, new Money(5.00m));

            Money expected = new Money(5.00m);
            Assert.That(account.CalculateBalance(), Is.EqualTo(expected));
        }

        [Test]
        public void WithdrawingCashDecreasesTheAccountBalance()
        {
            var account = new Account();
            account.Deposit(DateTime.Now, new Money(6m));
            var debitEntry = new ATMDebitEntry(DateTime.Now, new Money(2m));
            account.Withdraw(debitEntry);

            var expectedBalance = new Money(4m);
            Assert.That(account.CalculateBalance(), Is.EqualTo(expectedBalance));
        }
    }
}
