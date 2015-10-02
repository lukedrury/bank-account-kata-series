namespace BankingKata
{
    public interface IOverdraft
    {
        void Apply(IAccount account, DebitEntry withdrawal);
    }
}