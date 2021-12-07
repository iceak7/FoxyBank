using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public class SavingAccount : BankAccount
    {
        private decimal Interest { get; set; }

        public SavingAccount(int accountNr)
        {
            this.AccountNr = accountNr;
            this.Interest = 0.005m;
        }

        public decimal GetInterest()
        { 
            return Interest;
        }


    }
}
