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
        }
    }
}
