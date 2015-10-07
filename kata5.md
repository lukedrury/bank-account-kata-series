# Bank Account Kata 5

## Learning aims

Stick to the object callisthenics rules as much as possible. If you get absolutely stuck or do feel the need to break one of the rules, then go ahead. Make a note of which rule you broke and why, and then bring it up during the discussion group.

Some more things to think about before the discussion group:

1. Would some of these good practices be useful applied in our day-to-day work?
2. Do we see any of the bad ones in the code bases we work on?

## Tasks

Our banking application currently allows us to make cheque withdrawals, cash deposits, cash withdrawals, print last transactions, print current balance, and handle arranged and unarranged overdrafts. 

This is the final kata in the series, and now want you to string all the parts of this codebase together, to form an actual application. Through the application it should be possible to withdraw and deposit from a single account, as if using an ATM. The application should act as if you've already authenticated with the ATM, and so should present you with information on a single account.

### Setup

At start up the account state should be as follows:

* Initial balance of `£1000`
* Arranged overdraft of `£1500`
* The charge for going over the arranged overdraft should be `£10`.
* Unarranged overdraft limit of `£4000` (this means that it shouldn't be possible to withdraw money over `-£4000`, but that a charage should still be applied).

Don't attempt account persistence. That's out of scope for this kata.

### Console app

When ran, the console app should present you with the current account balance, and instructions on what to do next. The app should allow you to make a cash deposit, cash withdrawal, and view the last transaction.

An example usage of the console app might look something like:

> Welcome to your account.
>
> Balance: £1000
> 
> Press a key to choose an option:
>
> 1. Cash deposit
> 2. Cash withdrawal
> 3. Print last transaction
>
> 1 `//user input`
> 
> Enter an amount to deposit in pounds:
>
> 50 `//user input`
>
> Balance: £1050
> 
> Press a key to choose an option:

> 1. Cash deposit
> 2. Cash withdrawal
> 3. Print last transaction


After performing any operation, the app should print the new balance to the console.

Continue to try and write high quality code. Have as little code as possible in your main method, splitting functionality out into classes as usual.
