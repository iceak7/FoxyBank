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
        
        public Dictionary<int, int> Accounts { get; set; }

        public Bank()
        {
            this.Persons = new List<Person>();
            this.Accounts = new Dictionary<int, int>();

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

              
            foreach (var item in Persons)
            {
                if (newBankUser.UserId == item.UserId)
                {
                    idCount++;
                }
                else
                {
                    this.Persons.Add(newBankUser);
                    Console.WriteLine("User added to list");
                    Console.WriteLine("User information ");
                    Console.WriteLine("Name : {0} {1}", item.FirstName, item.LastName);
                    Console.WriteLine("ID : {0}", item.UserId);
                }
                
            }
        }




    }


}
