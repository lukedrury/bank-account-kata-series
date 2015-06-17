namespace BankingKata
{
    public interface ITransaction
    {
        Money ApplyTo(Money balance);
    }
}