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

        public void UserRunMenu()
        {
            bool isRunning = true;

            Console.WriteLine($"Välkommen {this.FirstName} {this.LastName}");

            do
            {
                Console.WriteLine("1. Se dina konton och saldo" +
                                "\n2. Överföring mellan egna konton" +
                                "\n3. Överföring till andra användares konton" +
                                "\n4. Skapa nytt bankkonto" +
                                "\n5. Logga ut");

                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        DisplayAllAccounts();
                        break;

                    case "2":
                        //InternalTransfer();
                        break;

                    case "3":
                        //ExternalTransfer();
                        break;
                    case "4":
                        //CreateAccount();
                        break;

                    case "5":
                        //LogOut();
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val.");
                        break;
                }
            }
            while (isRunning != false);

        }
    }
}
