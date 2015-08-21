# Bank Account Kata 4

## Learning aims

Stick to the object callisthenics rules as much as possible. If you get absolutely stuck or do feel the need to break one of the rules, then go ahead. Make a note of which rule you broke and why, and then bring it up during the discussion group.

Some more things to think about before the discussion group:

1. Would some of these good practices be useful applied in our day-to-day work?
2. Do we see any of the bad ones in the code bases we work on?

## Tasks

Our banking application currently allows us to make cheque withdrawals, cash deposits, cash withdrawals, print last transactions and print current balance. 

We now want you to add overdraft functionality. This should be done in stages:

1. Prevent transactions on an account that would take the balance of that account below a specific hard limit, e.g. -£1000.
   * This hard limit represents the most negative your balance can go through withdrawals (unarranged overdraft).
   * The bank will allow withdrawals upto, but not beyond, this point. A withdrawal will bounce if beyond the hard limit.
2. Add a charge to an account for any transaction that would take the balance below a soft limit, e.g. -£200.
   * This soft limit represents the most negative your balance can go before the bank will charge you (arranged overdraft).
   * A bank charge can take a balance below the hard (unarranged overdraft) limit.
   * The arranged overdraft limit cannot be more negative than the unarranged overdraft limit.
   
Regardless of how you implement your solution, make sure that the rules work together as described above.
   