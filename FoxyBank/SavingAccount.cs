using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public class SavingAccount : BankAccount
    {
        public decimal Interest { get; set;}

        public SavingAccount(int accountNr)
        {
            this.AccountNr = accountNr;
        }
    }
}
