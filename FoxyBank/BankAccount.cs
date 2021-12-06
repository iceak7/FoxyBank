using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public abstract class BankAccount
    {
        protected decimal Balance { get; set; }
        public int AccountNr { get; set; }
        public string AccountName { get; set; }
        public string CurrencySign { get; set; }
        public decimal RateSEKtoUSD { get; set; }
        public decimal RateUSDtoSEK { get; set; }

        public decimal GetBalance()
        {
            return Balance;
        }

        public void AddBalance(decimal sumToAdd)
        {
            Balance += sumToAdd;
        }

        public virtual decimal BalanceExFromUSD(decimal sumToAdd) ////FUNKAR INTE ATT OVERRIDE, VARFÖR???????
        {
            this.RateUSDtoSEK = 9.14m; //Necessary to add the rate here to make the function work, because of problem with override
            Balance += sumToAdd * RateUSDtoSEK;
            return Balance;
        }

        public virtual decimal BalanceExToUSD(decimal sumToAdd)
        {
            Balance += sumToAdd;
            return Balance;
        }

        public bool SubstractBalance(decimal sumToSubstract)
        {
            if (this.Balance >= sumToSubstract)
            {
                Balance-=sumToSubstract;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
