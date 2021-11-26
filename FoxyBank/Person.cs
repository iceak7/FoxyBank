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
        protected int UserId { get; set; }
        public bool Authentication(string password,int userid)
        {
            if(password == this.PassWord && userid == this.UserId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
