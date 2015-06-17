# bank account kata 2

## Learning aims

Building on the fun we had last time around with deposits and withdrawals and balances, the focus of this particular kata is "getting data out of a system without using properties".

Make sure you stick to TDD, and don't forget to stick to the full set of [object calisthenics rules](https://github.com/lukedrury/bank-account-kata-series/blob/kata2-start/README.md).

## Tasks

In this kata, your job is to write the C# code that allows a user to:

1. Print the current account balance
2. Print the last transaction

These should be printed to console. The expected format is:

For balances:

	Balance: £1,234.56

For transactions:

	Last transaction: 06 Jun 15, £1,234.56

**Tip**: You'll see in the starting code that our `Ledger` class has a method to accept an `ITransactionVisitor`. Currently this is only called from one place, with a visitor implementation that calculates the balance from the `Ledger`. This [Visitor Pattern](https://en.wikipedia.org/wiki/Visitor_pattern) is one way of accessing fully-encapsulated state, and it allows you to "add" new behaviours to an existing class without having to modify that class: great for the Open-Closed Principle.

## Extension
If you get all of the above done with time to spare, then try pretty-printing the output instead.

    Positive balances:      Negative balances:
    +---------+             +-----------+
    | Balance |             | Balance   |
    +---------+             +-----------+
    | £123.00 |             | (£123.00) |
    +---------+             +-----------+

    +-----------+           +-------------+
    | Balance   |           | Balance     |
    +-----------+           +-------------+
    | £1,234.00 |           | (£1,234.00) |
    +-----------+           +-------------+

    +---------------+       +-----------------+
    | Balance       |       | Balance         |
    +---------------+       +-----------------+
    | £1,234,567.00 |       | (£1,234,567.00) |
    +---------------+       +-----------------+
    

    Transactions:
    +-----------+--------------------+
    | Date      | Transaction Amount |
    +-----------+--------------------+
    | 06 Jun 15 |          £1,234.00 |
    +-----------+--------------------+

In words:
* The headers should be left justified
* Non-header cell contents should be right justified.
* Money should be printed in US format (with commas after every third order of magnitude, and a period separating pence).
* Dates should be printed in the format: "dd mmm yy" (without quotes), where "mmm" is the three letter abbreviation of the month.
* The cell contents should have padding of one space on their left and right.
* The horizontal table structure should be dashes (-).
* The vertical table structure should be made up of vertical bars (|).
* The intersections of the table structure should be pluses (+).
* The table structure should all line up correctly if printed to console, file, etc.
