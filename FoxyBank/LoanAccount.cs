using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    class LoanAccount : BankAccount
    {

        public LoanAccount(int accountNr)
        {
            this.AccountNr = accountNr;
        }
    }
}
