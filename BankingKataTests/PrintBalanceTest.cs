﻿using BankingKata;
using NSubstitute;
using NUnit.Framework;
using System;
using System.IO;

namespace BankingKataTests
{
    [TestFixture]
    public sealed class PrintBalanceTest
    {
        [Test]
        public void BalanceOfZeroIsPassedToThePrinter_ForANewAccount()
        {
            var account = new Account();

            IPrinter printer = Substitute.For<IPrinter>();
            account.PrintBalance(printer);

            printer.Received().PrintBalance(new Money(0m));
        }

        [Test]
        public void BalanceOfZeroIsPrinted_ForANewAccount()
        {
            var account = new Account();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            IPrinter printer = new ConsolePrinter();
            account.PrintBalance(printer);

            var output = stringWriter.GetStringBuilder();
            var expected = "Balance: £0.00";
            Assert.That(output.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void BalanceInThousandsIsPrinted()
        {
            var account = new Account();
            account.Deposit(DateTime.Now, new Money(1234.56m));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            IPrinter printer = new ConsolePrinter();
            account.PrintBalance(printer);

            var output = stringWriter.GetStringBuilder();
            var expected = "Balance: £1,234.56";
            Assert.That(output.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void LastTransactionIsPrinted()
        {
            var account = new Account();
            account.Deposit(DateTime.Now, new Money(123m));
            account.Deposit(DateTime.Now, new Money(456m));
            account.Deposit(new DateTime(2015, 07, 13), new Money(789m));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            IPrinter printer = new ConsolePrinter();
            account.PrintLastTransaction(printer);

            var output = stringWriter.GetStringBuilder();
            var expected = "Last transaction: DEP 13 Jul 2015 £789.00";
            Assert.That(output.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void CashWithdrawalIsPrinted()
        {
            var account = new Account();
            account.Withdraw(new DateTime(2015, 07, 13), new Money(123m));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            IPrinter printer = new ConsolePrinter();
            account.PrintLastTransaction(printer);

            var output = stringWriter.GetStringBuilder();
            var expected = "Last transaction: ATM 13 Jul 2015 (£123.00)";
            Assert.That(output.ToString(), Is.EqualTo(expected));
        }

        [TestCase(123456)]
        [TestCase(234567)]
        public void ChequeWithdrawalIsPrinted(int chequeNumber)
        {
            var chequeNumberProvider = Substitute.For<IChequeNumberProvider>();
            chequeNumberProvider.Next().Returns(chequeNumber);
            var account = new Account(new Ledger(), chequeNumberProvider);
            account.WithdrawCheque(new DateTime(2015, 07, 13), new Money(123m));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            IPrinter printer = new ConsolePrinter();
            account.PrintLastTransaction(printer);

            var output = stringWriter.GetStringBuilder();
            var expected = string.Format("Last transaction: CHQ {0} 13 Jul 2015 (£123.00)", chequeNumber);
            Assert.That(output.ToString(), Is.EqualTo(expected));
        }
    }
}
