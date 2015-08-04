using BankingKata;
using NSubstitute;
using NUnit.Framework;
using System;

namespace BankingKataTests
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void AccountRecordsDepositInTransactionLog()
        {
            var ledger = Substitute.For<ILedger>();
            var money = new Money(3m);
            var account = new Account(ledger, new ChequeNumberProvider());

            account.Deposit(DateTime.Now, money);

            CreditEntry deposit = new CreditEntry(DateTime.Now, money);
            ledger.Received().Record(deposit);
        }

        [Test]
        public void AccountRecordsWithdrawalInTransactionLog()
        {
            var ledger = Substitute.For<ILedger>();
            var money = new Money(3m);
            var account = new Account(ledger, new ChequeNumberProvider());

            account.Withdraw(DateTime.Now, money);

            var debitEntry = new DebitEntry(DateTime.Now, money);
            ledger.Received().Record(debitEntry);
        }

        [Test]
        public void AccountRecordsChequeWithdrawalInTransactionLog()
        {
            var ledger = Substitute.For<ILedger>();
            var money = new Money(3m);
            var account = new Account(ledger, new ChequeNumberProvider());

            account.WithdrawCheque(DateTime.Now, money);

            var chequeEntry = new ChequeEntry(DateTime.Now, money, 123456);
            ledger.Received().Record(chequeEntry);
        }
        
        [Test]
        public void CalculateBalanceTotalsAllDepositsMadeToTheAccount()
        {
            var ledger = Substitute.For<ILedger>();
            var account = new Account(ledger, new ChequeNumberProvider());

            account.CalculateBalance();

            ledger.Received().Accept(Arg.Any<BalanceCalculatingVisitor>(), new Money(0m));
        }

        [Test]
        public void LedgerTotalIsReturnedByCalculate()
        {
            var expectedBalance = new Money(13m);
            var ledger = Substitute.For<ILedger>();
            ledger.Accept(Arg.Any<BalanceCalculatingVisitor>(), new Money(0m)).Returns(expectedBalance);
            var account = new Account(ledger, new ChequeNumberProvider());

            var actualBalance = account.CalculateBalance();

            Assert.That(actualBalance, Is.EqualTo(expectedBalance));
        }
    }
}
