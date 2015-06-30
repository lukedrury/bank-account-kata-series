using System;
using System.IO;
using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    public class AccountBalanceTests
    {
        [Test]
        public void PrintedAccountBalanceIsTheCurrentBalance()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var account = new Account();
            account.Deposit(new Money(1m));

            account.Print();

            var outputString = stringWriter.ToString();
            Assert.That(outputString, Is.EqualTo("Balance: £1.00"));
        }
    }
}