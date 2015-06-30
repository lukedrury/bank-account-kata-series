using System;

namespace BankingKata
{
    public class LastTransactionDateVisitor : IDateVisitor
    {
        private readonly ITransaction m_Transaction;

        public LastTransactionDateVisitor(ITransaction transaction)
        {
            m_Transaction = transaction;
        }

        public ITransaction Visit(DateTime date)
        {
            return m_Transaction;
        }
    }
}