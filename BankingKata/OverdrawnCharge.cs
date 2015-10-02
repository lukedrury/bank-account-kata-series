using System;

namespace BankingKata
{
    public class OverdrawnCharge : DebitEntry
    {
        public OverdrawnCharge(DateTime transactionDate, Money charge) : base(transactionDate, charge)
        {
        }

        public override string ToString()
        {
            return string.Format("OVR {0}", base.ToString());
        }
    }
}