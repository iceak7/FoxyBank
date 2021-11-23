using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    class User:Person
    {

        List<Account> Account = new List<Account>();

        public User(string firstName, string lastName, string passWord)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PassWord = passWord;


        }
        public void DisplayAllAccount()
        {

        }
    }
}
