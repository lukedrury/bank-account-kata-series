namespace BankingKata
{
    public class UnarrangedOverdraft : IOverdraft
    {
        private readonly Money m_OverdraftLimit;

        public UnarrangedOverdraft(Money overdraftLimit)
        {
            m_OverdraftLimit = overdraftLimit;
        }

        public void Apply(IAccount account, DebitEntry withdrawal)
        {
            var balanceAfterWithdrawal = withdrawal.ApplyTo(account.CalculateBalance());

            if (balanceAfterWithdrawal < m_OverdraftLimit)
            {
                throw new OverdraftLimitReachedException();
            }
        }
    }
}