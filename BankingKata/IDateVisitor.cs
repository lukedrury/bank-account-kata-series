using System;

namespace BankingKata
{
    public interface IDateVisitor
    {
        ITransaction Visit(DateTime date);
    }
}