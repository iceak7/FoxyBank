using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{

    public class User:Person
    {

        public List<Account> Accounts { get; set; }


        public User(string firstName, string lastName, string passWord, int userId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PassWord = passWord;
            this.UserId = userId;
            this.Accounts = new List<Account>();
        }
        public void DisplayAllAccounts()
        {

        }
       

    }
}
