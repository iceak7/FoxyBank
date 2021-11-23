using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    class Admin:Person
    {
        public Admin()
        {
            this.FirstName = "Admin";
            this.LastName = "Admin";
            this.PassWord = "Hemlis";
        }
        public Admin(string firstName, string lastName, string passWord)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PassWord = passWord;


        }
        public void RegisterNewUser()
        {
            //Register user
        }
    }
}
