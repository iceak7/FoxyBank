using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public class Bank
    {
        public List<Person> Persons { get; set; }

        public void StartApplication()
        {
            Console.WriteLine("Hej välkommen till Foxy Bank.");

            Person loggedInPerson = Login();
            if(loggedInPerson == null)
            {
                Console.WriteLine("Failed.");
                
            }

        }

        public Person Login()
        {
            //Fråga efter userid och lösen.
            //Kolla i listan om den användaren finns och uppgifterna är korrekta
            //Returnera användaren som loggade in och null om den inte fanns
            return null;
        }


        
    }


}
