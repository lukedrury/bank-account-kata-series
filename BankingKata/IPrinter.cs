namespace BankingKata
{
    public interface IPrinter
    {
        void PrintBalance(Money balance);
        void PrintLastTransaction(ILedger ledger);
    }
}