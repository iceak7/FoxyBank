using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public class LoanAccount : BankAccount
    {
        protected decimal Interest { get; set; }
        

        public LoanAccount(int accountNr)
        {
            this.Balance = 0;
            this.AccountNr = accountNr;
        }

        public LoanAccount()
        {
        }

        public decimal GetInterest()
        {
            return Interest;
        }
    }
}
