using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public class Bank
    {
        public Bank()
        {
            this.Persons = new List<Person>();
        }
        public List<Person> Persons { get; set; }

        public void StartApplication()
        {
            Console.WriteLine("Hej välkommen till Foxy Bank.");

            Person loggedInPerson = Login();
            if(loggedInPerson == null)
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
                if(A1.Authentication(AnPassword, AnId))
                {
                    return A1;
                } 
                
            }return null;
            
            //Fråga efter userid och lösen.
            //Kolla i listan om den användaren finns och uppgifterna är korrekta
            //Returnera användaren som loggade in och null om den inte fanns
            
        }




        
    }


}
