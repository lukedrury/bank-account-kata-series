namespace BankingKata
{
    public interface ITransaction
    {
        Money ApplyTo(Money balance);
        ITransaction Accept(IDateVisitor visitor);
    }
}