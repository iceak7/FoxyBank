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
            this.UserId = 1001;
        }
        public Admin(string firstName, string lastName, string passWord)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PassWord = passWord;


        }
        public void RegisterNewUser(Bank bank)
        {
            //First user = 2001
            //Register user
            //Generate ID - check if ID already exists
            //bank.Persons.Add(new User())

            //bank.Persons

        }

        bool isRunning = true;
        public void AdminRunMenu()
        {

            Console.WriteLine($"Välkommen {this.FirstName} {this.LastName}");

            do
            {
                Console.WriteLine("1. Skapa ny bankkund" +
                                "\n2. Ändra valutakurs" +
                                "\n3. Logga ut");

                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        RegisterNewUser();
                        break;


                    case "2":
                        updateExchangeRate();
                        break;

                    case "3":
                        LogOut();
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
