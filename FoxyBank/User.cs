using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{

    public class User:Person
    {

        public List<BankAccount> BankAccounts { get; set; }


        public User(string firstName, string lastName, string passWord, int userId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PassWord = passWord;
            this.UserId = userId;
            this.BankAccounts = new List<BankAccount>();
        }
               
        public void DisplayAllAccounts()
        {
            if (BankAccounts.Count == 0)
            {
                Console.WriteLine("Inga tillgängliga konton.");
            }
            else
            {
                foreach (BankAccount created in BankAccounts)
                {
                    Console.WriteLine($"Kontonamn: {created.AccountName} " +
                                    $"\nKontonummer: {created.AccountNr} " +
                                    $"\nTillgängligt belopp: {created.GetBalance()}" +
                                    $"\n");
                }
            }
        }
        
    }
}
