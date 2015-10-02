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

        [Test]
        public void WithdrawingMoreThanOverdraftLimitThrowsException()
        {
            var accountWithOverdraft = new AccountWithOverdraft(new Account(), new UnarrangedOverdraft(new Money(-1000m)));

            var debitEntry = new ATMDebitEntry(DateTime.Now, new Money(1001m));
            Assert.Throws<OverdraftLimitReachedException>(() => accountWithOverdraft.Withdraw(debitEntry));
        }

        [Test]
        public void WithdrawingLessThanOverdraftLimitDoesNotThrowsException()
        {
            var accountWithOverdraft = new AccountWithOverdraft(new Account(), new UnarrangedOverdraft(new Money(-1000m)));

            var debitEntry = new ATMDebitEntry(DateTime.Now, new Money(999m));
            Assert.DoesNotThrow(() => accountWithOverdraft.Withdraw(debitEntry));
        }

        [Test]
        public void WithdrawingMoreThanArrangedOverdraftLimit()
        {
            var accountWithOverdraft = new AccountWithOverdraft(new Account(), new ArrangedOverdraft(new Money(-200m), new Money(2.50m)));

            var debitEntry = new ATMDebitEntry(DateTime.Now, new Money(201m));
            Assert.DoesNotThrow(() => accountWithOverdraft.Withdraw(debitEntry));

            var balance = accountWithOverdraft.CalculateBalance();
            Assert.That(balance, Is.EqualTo(new Money(-203.5m)));
        }

        [Test]
        public void WithdrawingMoreThanArrangedOverdraftLimitCanExceedUnarrangedLimitDueToCharge()
        {
            var accountWithArrangedOverdraft = new AccountWithOverdraft(new Account(), new ArrangedOverdraft(new Money(-200m), new Money(2.50m)));
            var accountWithUnarrangedOverdraft = new AccountWithOverdraft(accountWithArrangedOverdraft, new UnarrangedOverdraft(new Money(-202m)));

            var debitEntry = new ATMDebitEntry(DateTime.Now, new Money(201m));
            Assert.DoesNotThrow(() => accountWithUnarrangedOverdraft.Withdraw(debitEntry));

            var balance = accountWithUnarrangedOverdraft.CalculateBalance();
            Assert.That(balance, Is.EqualTo(new Money(-203.5m)));
        }

        [Test]
        public void WithdrawingMoreThanUnarrangedOverdraftLimitWhenArrangedOverdraftExistsThrowsException()
        {
            var accountWithArrangedOverdraft = new AccountWithOverdraft(new Account(), new ArrangedOverdraft(new Money(-200m), new Money(2.50m)));
            var accountWithUnarrangedOverdraft = new AccountWithOverdraft(accountWithArrangedOverdraft, new UnarrangedOverdraft(new Money(-202m)));

            var debitEntry = new ATMDebitEntry(DateTime.Now, new Money(203m));
            Assert.Throws<OverdraftLimitReachedException>(() => accountWithUnarrangedOverdraft.Withdraw(debitEntry));
        }
    }
}
