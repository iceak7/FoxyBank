using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public class ForeignAccount : BankAccount
    {

        public decimal rateSEKtoUSD = 0.11m;
        public decimal rateUSDtoSEK = 9.14m;


        public ForeignAccount(int accountNr)
        {
            this.AccountNr = accountNr;
            this.Balance = (0 * rateSEKtoUSD);
        }

        public override void BalanceExToUSD(decimal sumToAdd)
        {
            Balance += sumToAdd * rateSEKtoUSD;
        }

        public override void BalanceExFromUSD(decimal sumToAdd)
        {
            Balance += sumToAdd * rateUSDtoSEK;
        }

    }
}
