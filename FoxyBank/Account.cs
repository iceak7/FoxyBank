using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public abstract class Account
    {
        protected decimal Balance { get; set; }
        public int AccountNr { get; set; }
        public string AccountName { get; set; }
    }
}
