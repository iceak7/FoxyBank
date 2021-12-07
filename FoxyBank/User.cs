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
            foreach (BankAccount created in BankAccounts)
            {
                if (created is SavingAccount)
                {
                    SavingAccount S = (SavingAccount)created;
                    Console.WriteLine($"Kontonamn: {S.AccountName} " +
                               $"\nKontonummer: {S.AccountNr} " +
                               $"\nTillgängligt belopp: {S.GetBalance()}" +
                                $" Ränta = { string.Format("{0:0.00}", S.GetInterest() * S.GetBalance())}" +". Räntan ligger på "+ S.GetInterest()+"%." +
                                $"\n") ;
                }
                else
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
