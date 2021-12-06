using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public class ForeignAccount : BankAccount
    {
        public ForeignAccount(int accountNr)
        {
            this.Balance = 0;
            this.AccountNr = accountNr;
            this.RateSEKtoUSD = 0.11m;
            this.RateUSDtoSEK = 9.14m;
        }

        public override decimal BalanceExToUSD(decimal sumToAdd)
        {
            Balance += sumToAdd * RateSEKtoUSD;                    
            return Balance;
        }

        public override decimal BalanceExFromUSD(decimal sumToAdd)
        {
            Balance += sumToAdd * RateUSDtoSEK;
            return Balance;
        }

    }
}
