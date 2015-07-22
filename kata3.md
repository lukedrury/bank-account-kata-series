# Bank Account Kata 3

## Learning aims

Stick to the object calisthenics rules as much as possible. If you get absolutely stuck or do feel the need to break one of the rules, then go ahead. Make a note of which rule you broke and why, and then bring it up during the discussion group.

Some more things to think about before the discussion group:

1. Would some of these good practices be useful applied in our day-to-day work?
2. Do we see any of the bad ones in the code bases we work on?

## Tasks

Our banking application currently allows us to make cash deposits, cash withdrawals, print last transactions and print current balance. The next task is to add a new type of transaction, cheque withdrawals.

A cheque withdrawal happens when you write a cheque to give to someone else and they cash it. A cheque withdrawal transaction is recorded against your account when the cheque has cleared into their account. The cheques you write have a cheque number, a date, and an amount.

Write the code to:

1. **Withdraw a cheque from an account.** As well as a withdrawal amount, a cheque also has a six-digit cheque number (e.g. 100001).
   * For the purposes of this kata, assume cheque numbers can be any six-digit integer.
2. **Adapt printing transactions to support cheques.** As a result, we need to distinguish between cheque withdrawals and cash withdrawals. We use transaction codes as follows to achieve this:
   * Deposit: `DEP`
   * Cash withdrawal: `ATM`
   * Cheque withdrawal: `CHQ`

## Example

What does this mean in practice? Extend the code such that, if the last transaction was a withdrawal of £50 via cheque no. 100015, then printing the last transaction will give:

	Last transaction: CHQ 100015 06 Jun 15 (£50.00)

and if the last transaction was a cash deposit of £10, then printing the last transaction will give:

	Last transaction: DEP 06 Jun 15 £10.00

Printing the balance should be unchanged by these tasks.
