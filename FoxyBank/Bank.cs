﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public class Bank
    {
        public List<Person> Persons { get; set; }
        public Dictionary<int, int> BankAccounts { get; set; }

        public Bank()
        {
            this.Persons = new List<Person>();
            this.BankAccounts = new Dictionary<int, int>();
        }
        public void StartApplication()
        {   
            Console.WriteLine("Hej välkommen till Foxy Bank.");

            byte Tries = 3;

            do
            {
                Person loggedInPerson = Login();
                if (loggedInPerson == null)
                {
                    Console.WriteLine("Misslyckad inloggning.");
                    Tries--;
                }
                else
                {
                    Console.WriteLine("Du är inloggad.");
                    char firstDigit = loggedInPerson.UserId.ToString()[0];

                
                if (firstDigit == '1')              //All users with Admin function has an ID which starts with nr 1
                {
                    RunAdminMenu((Admin)loggedInPerson);
                }
                else
                {
                    RunUserMenu((User)loggedInPerson);
                }

                    break;
                }

            } while (Tries > 0);   

        }

        public Person Login()
        {

           
            bool Answear;
            int AnId;
            do {

                Console.WriteLine("Skriv användarID");
                Answear = int.TryParse(Console.ReadLine(), out AnId);
                if (Answear == false)
                {
                    Console.Clear();
                    return null;

                }
            } while (Answear == false);
            Console.WriteLine("Skriv in lösenord");

            string AnPassword = Console.ReadLine();

            foreach (Person A1 in Persons)
            {
                if (A1.Authentication(AnPassword, AnId))
                {
                    return A1;
                }
            }
            return null;
        }

        public int GenerateUserID()
        {
            bool IDCheck = true;
            Random random = new Random();
            int randomizeID = 0;
            do
            {
                IDCheck = true;
                randomizeID = random.Next(2000, 3000);
                foreach (var item in Persons)
                {
                    if (randomizeID == item.UserId)
                    {

                        IDCheck = false;
                    }
                    
                }
            }
            while (IDCheck == false);
            
            return randomizeID;




        }
        public void RunAdminMenu(Admin loggedInPerson)
        {
            bool isRunning = true;

            do
            {
                Console.WriteLine($"\nHej {loggedInPerson.FirstName} {loggedInPerson.LastName}. Vad vill du göra?");

                Console.WriteLine("\nAnvändarmeny för administrator:" +
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

      
        public void RunUserMenu(User loggedInPerson)

        {
            bool isRunning = true;

            do
            {
                Console.WriteLine($"\nHej {loggedInPerson.FirstName} {loggedInPerson.LastName}. Vad vill du göra:");
                Console.WriteLine("\n1. Se dina konton och saldo" +
                        "\n2. Överför pengar" +
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
                        TransferMoney(loggedInPerson);
                        break;

                    case "3":
                        //ExternalTransfer();
                        break;
                    case "4":


                        CreateAccount(loggedInPerson);

                        break;

                    case "5":
                        //LogOut();
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("\nOgiltigt val.");
                        break;
                }
            }
            while (isRunning != false);
        }

        public void RegisterNewUser()
        {


            Console.WriteLine("Var god skriv in användarens förnamn");
            string firstNameInput = Console.ReadLine();
            Console.WriteLine("Var god skriv in användarens efternamn");
            string lastNameInput = Console.ReadLine();
            Console.WriteLine("Var god skriv in användarens lösenord");
            string passWordInput = Console.ReadLine();
            User newBankUser = new User(firstNameInput, lastNameInput, passWordInput, GenerateUserID());

            this.Persons.Add(newBankUser);
            Console.WriteLine("Ny användare tillagd.");
            Console.WriteLine("Användarinfo");
            Console.WriteLine("Namn : {0} {1}", newBankUser.FirstName, newBankUser.LastName);
            Console.WriteLine("Lösenord : {0}",newBankUser.PassWord);
            Console.WriteLine("ID : {0}", newBankUser.UserId);
            Console.ReadKey();




        }

        public int GenerateAccountNr()
        {
            int accountNr = 0;

            Random rand = new Random();
            int randomizedAccNr = rand.Next(10000, 11000);

            if (!BankAccounts.ContainsKey(randomizedAccNr)) { accountNr = randomizedAccNr; }
            else
            {
                bool foundId = false;
                while (!foundId)
                {
                    randomizedAccNr = rand.Next(10000, 11000);
                    if (!BankAccounts.ContainsKey(randomizedAccNr))
                    {
                        accountNr = randomizedAccNr;
                        foundId = true;
                    }
                }
            }

            return accountNr;
        }

        public void CreateAccount(User user)
        {
            
            BankAccount createdAccount = null;

            Console.WriteLine("\nVad vill du öppna för konto?");
            do
            {
                Console.WriteLine("\n1.Sparkonto");
                Console.WriteLine("2.Personkonto\n");

                string answer = Console.ReadLine();


                if (answer == "1")
                {
                    createdAccount = new SavingAccount(GenerateAccountNr());
                    user.BankAccounts.Add(createdAccount);
                    this.BankAccounts.Add(createdAccount.AccountNr, user.UserId);

                }

                else if (answer == "2")
                {
                    createdAccount = new PersonalAccount(GenerateAccountNr());
                    user.BankAccounts.Add(createdAccount);
                    this.BankAccounts.Add(createdAccount.AccountNr, user.UserId);

                }
                else
                {
                    Console.WriteLine("Vänligen välj vilket typ av konto du vill öppna. Svara ett nummer från menyn.");
                }

            } while (createdAccount == null);

            Console.WriteLine($"\nGrattis! Du skapade ett {((createdAccount is PersonalAccount) ? "Personkonto" : "Sparkonto")} med kontonumret " + createdAccount.AccountNr);
        }

        public void TransferMoney(User user)
        {
            int transferFromAcc = 0;
            user.DisplayAllAccounts();

            Console.WriteLine("\nVilket konto vill du överföra pengar ifrån? Skriv kontonumret.");
            do
            {
                int inputAcc = 0;
                if (int.TryParse(Console.ReadLine(), out inputAcc))
                {
                    BankAccount foundAcc = user.BankAccounts.Find(x => x.AccountNr == inputAcc);
                    if (foundAcc != null )
                    {
                        if (foundAcc.GetBalance() > 0)
                        {
                            transferFromAcc = foundAcc.AccountNr;
                        }
                        else
                        {
                            Console.WriteLine("Konto du valde har inte tillräckligt högt saldo. Vänligen välj ett annat konto.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Inget konton med det kontonumret du matade in hittades. Vänligen testa att skriva kontonumret igen.");
                    }
                }
                else
                {
                    Console.WriteLine("Vänligen mata in ett korrekt kontonummer. Vänligen testa att skriva kontonumret igen.");
                }
            } while (transferFromAcc == 0);


            int transferToAcc = 0;
            Console.WriteLine("\nVilket konto vill du överföra pengar till? Skriv kontonumret.");
            do
            {
                int inputAcc = 0;
                if (int.TryParse(Console.ReadLine(), out inputAcc))
                {

                    if (transferFromAcc == inputAcc)
                    {
                        Console.WriteLine("Vänligen välj ett annat konto än det du ska överför pengar ifrån.");
                    }
                    else if (this.BankAccounts.ContainsKey(inputAcc))
                    {
                        
                        if (this.BankAccounts[inputAcc]!=user.UserId)
                        {
                            User transferToUser = (User)this.Persons.Find(x => x.UserId == this.BankAccounts[inputAcc]);

                            Console.WriteLine($"Kontot du valde med kontonummer {inputAcc} tillhör {transferToUser.FirstName} {transferToUser.LastName}. \nÄr du säker att du vill överföra pengar till detta konto? Svara \"Ja\" isåfall. Klicka bara vidare annars för att skriva in kontonumret på nytt.");

                            if (Console.ReadLine().ToUpper() == "JA")
                            {
                                transferToAcc = inputAcc;
                            }
                            else
                            {
                                Console.WriteLine("Vänligen skriv kontonumret på kontot du vill överföra pengar till.");
                            }
                        }
                        else
                        {
                            transferToAcc = inputAcc;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Inget konton med det kontonumret du matade in hittades. Vänligen testa att skriva kontonumret igen.");
                    }
                }
                else
                {
                    Console.WriteLine("Vänligen mata in ett korrekt kontonummer. Vänligen testa att skriva kontonumret igen.");
                }
            } while (transferToAcc == 0);

            Console.WriteLine(transferToAcc);



        }
    }
}


