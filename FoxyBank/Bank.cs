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
            RegisterNewUser();
            //Person loggedInPerson = Login();
            //if(loggedInPerson == null)
            //{
            //    Console.WriteLine("Failed.");
                
            //}

        }

        public Person Login()
        {
            //Fråga efter userid och lösen.
            //Kolla i listan om den användaren finns och uppgifterna är korrekta
            //Returnera användaren som loggade in och null om den inte fanns
            return null;
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
            
            User newBankUser = new User(Firstnameinput,Lastnameinput,"hemlis123",GenerateUserID());
            
            

            this.Persons.Add(newBankUser);
            foreach (var item in Persons)
            {
                Console.WriteLine("User added to list");
                Console.WriteLine("User information ");
                Console.WriteLine("Name : {0} {1}", item.FirstName,item.LastName);
                Console.WriteLine("ID : {0}",item.UserId);
            }


            //First user = 2001
            //Register user
            //Generate ID - check if ID already exists
            //bank.Persons.Add(new User())

            //bank.Persons

        }




    }


}
