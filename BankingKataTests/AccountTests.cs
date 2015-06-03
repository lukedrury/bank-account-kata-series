using System;
using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void TheLastTransactionInAnSingleTransactionAccountIsThatTransaction()
        {
            var account = new Account();

            account.Deposit(new Money(0), new DateTime(0));
            var lastTransaction = account.LastTransaction();

            var expectedTransaction = new Transaction(new Money(0), new DateTime(0));
            Assert.That(lastTransaction, Is.EqualTo(expectedTransaction));
        }

        [Test]
        public void TheLastTransactionInAMultipleTransactionAccountIsThatTransaction()
        {
            var account = new Account();

            account.Deposit(new Money(0), new DateTime(0));
            account.Deposit(new Money(1), new DateTime(1));
            account.Deposit(new Money(2), new DateTime(2));
            var lastTransaction = account.LastTransaction();

            var expectedTransaction = new Transaction(new Money(2), new DateTime(2));
            Assert.That(lastTransaction, Is.EqualTo(expectedTransaction));
        }

        [Test]
        public void TheDepositOnlyAcceptsValuesGreaterThanZero()
        {
            var account = new Account();

            Assert.Throws<InvalidDepositException>(() => { account.Deposit(new Money(-1), new DateTime(0)); });
        }
    }
}