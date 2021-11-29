using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public class Bank
    {
        //Fields för generateIDmethod

        static int idCount = 2000;

        public List<Person> Persons { get; set; }

        public Bank()
        {
            this.Persons = new List<Person>();
        }
        public void StartApplication()
        {
            Console.WriteLine("Hej välkommen till Foxy Bank.");

            Person loggedInPerson = Login();
            if (loggedInPerson == null)
            {
                Console.WriteLine("Failed.");

            }
            else
            {
                Console.WriteLine("Your now logged in!");
                char firstDigit = loggedInPerson.UserId.ToString()[0];

                if (firstDigit == '1')
                {
                    RunAdminMenu(loggedInPerson);
                }
                else
                {
                    RunUserMenu(loggedInPerson);
                }
            }
        }

        public Person Login()
        {

            Console.WriteLine("Write user id.");
            int AnId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter password.");
            string AnPassword = Console.ReadLine();

            foreach (Person A1 in Persons)
            {
                if (A1.Authentication(AnPassword, AnId))
                {
                    return A1;
                }
            }
            return null;

            //Fråga efter userid och lösen.
            //Kolla i listan om den användaren finns och uppgifterna är korrekta
            //Returnera användaren som loggade in och null om den inte fanns

        }

        public void RunAdminMenu(Person loggedInPerson)
        {
            bool isRunning = true;

            do
            {
                Console.WriteLine($"Hej {loggedInPerson.FirstName} {loggedInPerson.LastName}. Vad vill du göra?");

                Console.WriteLine("Användarmeny för administrator:" +
                            "\n1. Skapa ny bankkund" +
                            "\n2. Ändra valutakurs" +
                            "\n3. Ändra sparränta" +
                            "\n4 Logga ut");

                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        RegisterNewUser();
                        break;
                    case "2":
                        //ExchangeRate();
                        break;

                    case "3":
                        //InterestRate();
                        break;

                    case "4":
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

        public void RunUserMenu(Person loggedInPerson)
        {
            bool isRunning = true;

            do
            {
                Console.WriteLine($"Hej {loggedInPerson.FirstName} {loggedInPerson.LastName}. Vad vill du göra:");
                Console.WriteLine("1. Se dina konton och saldo" +
                        "\n2. Överföring mellan egna konton" +
                        "\n3. Överföring till andra användares konton" +
                        "\n4. Skapa nytt bankkonto" +
                        "\n5. Logga ut");

                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        //DisplayAllAccounts();
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


        //Metod som genererar ett id till User, börjar från 2001
        public int GenerateUserID()
        {
            idCount++;

            return idCount;
        }
        public void RegisterNewUser()
        {

            Console.WriteLine("Please type in the first name of the new user");
            string Firstnameinput = Console.ReadLine();
            Console.WriteLine("Please type in the last name of the new user");
            string Lastnameinput = Console.ReadLine();

            User newBankUser = new User(Firstnameinput, Lastnameinput, "hemlis123", GenerateUserID());



            this.Persons.Add(newBankUser);
            foreach (var item in Persons)
            {
                Console.WriteLine("User added to list");
                Console.WriteLine("User information ");
                Console.WriteLine("Name : {0} {1}", item.FirstName, item.LastName);
                Console.WriteLine("ID : {0}", item.UserId);
            }

            //First user = 2001
            //Register user
            //Generate ID - check if ID already exists
            //bank.Persons.Add(new User())

            //bank.Persons

        }
    }
}


