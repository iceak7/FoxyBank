using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public class Admin:Person
    {
        
        public Admin()
        {
            this.FirstName = "Admin";
            this.LastName = "Admin";
            this.PassWord = "Hemlis";
            this.UserId = 1001;
        }
        public Admin(string firstName, string lastName, string passWord)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PassWord = passWord;

        }


    }
}
