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
            if(loggedInPerson == null)
            {
                Console.WriteLine("Failed.");

            }
            else
            {
                Console.WriteLine("You are now logged in!");
            }


        }

        public Person Login()
        {
            
            Console.WriteLine("Write user id.");
            int AnId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter password.");
            string APassword = Console.ReadLine();

            foreach (Person A1 in Persons)
            {
                if(A1.Authentication(APassword, AnId))
                {
                    return A1;
                } 
                
            }return null;
            
            //Fråga efter userid och lösen.
            //Kolla i listan om den användaren finns och uppgifterna är korrekta
            //Returnera användaren som loggade in och null om den inte fanns
            
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

        public void CreateAccount(User user)
        {
            int accountNr=0;

            Random rand = new Random();
            int randomizedAccNr = rand.Next(10000, 11000);

            if (!Accounts.ContainsKey(randomizedAccNr)) { accountNr = randomizedAccNr; }
            else
            {
                bool foundId = false;
                while (!foundId)
                {
                    randomizedAccNr = rand.Next(10000, 11000);
                    if (!Accounts.ContainsKey(randomizedAccNr)) 
                    { 
                        accountNr = randomizedAccNr;
                        foundId = true;
                    }
                }
            }

            Account createdAccount = null;

            Console.WriteLine("\nVad vill du öppna för konto?");
            do
            {
                Console.WriteLine("\n1.Sparkonto");
                Console.WriteLine("2.Personkonto\n");

                string answer = Console.ReadLine();


                if (answer == "1")
                {
                    createdAccount = new SavingAccount(accountNr);
                    user.Accounts.Add(createdAccount);
                    this.Accounts.Add(createdAccount.AccountNr, user.UserId);

                }

                else if (answer == "2")
                {
                    createdAccount = new PersonalAccount(accountNr);
                    user.Accounts.Add(createdAccount);
                    this.Accounts.Add(createdAccount.AccountNr, user.UserId);
                   
                }
                else
                {
                    Console.WriteLine("Vänligen välj vilket typ av konto du vill öppna. Svara ett nummer från menyn.");
                }

            } while (createdAccount==null);

            Console.WriteLine($"\nGrattis! Du skapade ett {((createdAccount is PersonalAccount)? "Personkonto" : "Sparkonto" )} med kontonumret " + createdAccount.AccountNr);
        }


    }


}
