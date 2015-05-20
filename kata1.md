# Bank Account Kata 1

## Learning aims

### Primary - create a small program using Object Calisthenics

These are explained in detail in the [readme.md](README.md) for this repository.

The idea here is to attempt to solve a problem while taking certain object-oriented design principles to extremes. By doing this, we're exerting our programming skills in a different way to normal, forcing us to think differently. As a result of doing this, we'll most like get some smelly code in certain areas, and lovely code in others. Don't divert off the object calisthenics course when things start getting hairy; for the kata to work, we all need to experience the benefits and the drawbacks of programming in this way.

One important note, though. Object calisthenics states that you must "wrap all primitive types and strings". We are interpreting that rule to mean:

1. Primitive types may only be accepted by constructors (otherwise primitives cannot be wrapped).
2. Primitives may only be *returned* by implementations of the `Equals` and `GetHashCode` methods you find necessary to add, and for any [overloaded *comparison* operators](https://msdn.microsoft.com/en-us/library/8edha89s.aspx) you choose to implement.

### Secondary - use Test-Driven Development to build your program (while adhering to object calisthenics)

Using TDD will introduce you to some of the more interesting design decisions that must be taken while following object calisthenics. 

## Task

Make sure you’ve read the [object calisthenics section of the readme.md](https://github.com/lukedrury/bank-account-kata-series-source/blob/kata1_simplified/README.md#object-calisthenics) before starting the kata.

Write the C# code to:

1. Record a cash deposit into an account
2. Record a cash withdrawal

## Advice

Consider keeping the list of object calisthenics rules to hand for cross-referencing with your implementation.

Remember that you're not allowed to create getters or setters. This means you will have to find another way to write your tests, other than grabbing values out of the classes you're testing.

You will probably be creating Value Objects, so it would be good to brush up on their characteristics. Martin Fowler’s brief description is a particularly good one http://martinfowler.com/bliki/ValueObject.html.
