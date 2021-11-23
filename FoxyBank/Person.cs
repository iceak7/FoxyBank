using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        protected string PassWord { get; set; }
        private int UserId { get; set; }
    }
}
