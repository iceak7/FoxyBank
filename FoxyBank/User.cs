using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    class User : Person
    {

        List<Account> Account = new List<Account>();


        public User(string firstName, string lastName, string passWord, int userId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PassWord = passWord;
            this.UserId = userId;
        }
        public void DisplayAllAccounts()
        {

        }

        public void CreateAccount()
        {
            Console.WriteLine("Vad vill du öppna för konto?");
            Console.WriteLine("1.Sparkonto");
            Console.WriteLine("2.Personkonto");

            string answer = Console.ReadLine();

            if (answer == "1")
            {

            }

            else if (answer == "2")
            {

            }
            else
            {

            }
        }

    }
}
