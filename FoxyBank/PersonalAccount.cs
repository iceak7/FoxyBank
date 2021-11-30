using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public class PersonalAccount : Account
    {
        public PersonalAccount(int accountNr)
        {
            this.Balance = 0;
            this.AccountNr = accountNr;

        }


    }
}
