using System;
using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void TheLastTransactionInAnSingleDepositAccountIsThatDeposit()
        {
            var account = new Account();

            account.Deposit(new Money(1), new DateTime(0));
            var lastTransaction = account.LastTransaction();

            var expectedTransaction = new Transaction(new Money(1), new DateTime(0));
            Assert.That(lastTransaction, Is.EqualTo(expectedTransaction));
        }

        [Test]
        public void TheLastTransactionInAMultipleDepositAccountIsTheLastDeposit()
        {
            var account = new Account();

            account.Deposit(new Money(1), new DateTime(0));
            account.Deposit(new Money(2), new DateTime(1));
            account.Deposit(new Money(3), new DateTime(2));
            var lastTransaction = account.LastTransaction();

            var expectedTransaction = new Transaction(new Money(3), new DateTime(2));
            Assert.That(lastTransaction, Is.EqualTo(expectedTransaction));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void TheDepositOnlyAcceptsValuesGreaterThanZero(int amount)
        {
            var account = new Account();

            Assert.Throws<InvalidDepositException>(() => { account.Deposit(new Money(amount), new DateTime(0)); });
        }

        [Test]
        public void TheLastTransactionInAnSingleWithdrawalAccountIsThatWithdrawal()
        {
            var account = new Account();

            account.Withdrawal(new Money(1), new DateTime(0));
            var lastTransaction = account.LastTransaction();

            var expectedTransaction = new Transaction(new Money(-1), new DateTime(0));
            Assert.That(lastTransaction, Is.EqualTo(expectedTransaction));
        }

        [Test]
        public void TheLastTransactionInAMultipleWithdrawalAccountIsTheLastWithdrawal()
        {
            var account = new Account();

            account.Withdrawal(new Money(1), new DateTime(0));
            account.Withdrawal(new Money(2), new DateTime(1));
            account.Withdrawal(new Money(3), new DateTime(2));
            var lastTransaction = account.LastTransaction();

            var expectedTransaction = new Transaction(new Money(-3), new DateTime(2));
            Assert.That(lastTransaction, Is.EqualTo(expectedTransaction));
        }
    }
}