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
    }
}