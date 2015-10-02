namespace BankingKata
{
    public class ArrangedOverdraft : IOverdraft
    {
        private readonly Money m_ArrangedOverdraft;
        private readonly Money m_Charge;

        public ArrangedOverdraft(Money arrangedOverdraft, Money charge)
        {
            m_ArrangedOverdraft = arrangedOverdraft;
            m_Charge = charge;
        }

        public void Apply(IAccount account, DebitEntry withdrawal)
        {
            var balanceAfterWithdrawal = withdrawal.ApplyTo(account.CalculateBalance());

            if (balanceAfterWithdrawal < m_ArrangedOverdraft)
            {
                account.Withdraw(withdrawal.CreateOverdraftCharge(m_Charge));
            }
        }
    }
}