namespace BankingKata
{
    public class LastTransactionVisitor : ITransactionVisitor<ITransaction>
    {
        public ITransaction Visit(ITransaction currentTransaction, ITransaction mostRecentTransactionSoFar)
        {
            var lastTransactionDateVisitor = new LastTransactionDateVisitor(currentTransaction);
            return mostRecentTransactionSoFar.Accept(lastTransactionDateVisitor); ;
        }
    }
}