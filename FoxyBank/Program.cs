using System;
using Newtonsoft.Json;
using System.IO;

namespace FoxyBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank ourBank = new Bank();
            InitializeUsers(ourBank);
            ourBank.StartApplication();
        }

        static void InitializeUsers(Bank bank)
        {
            bank.Persons.Add(new Admin("Admin", "Adminsson", "Hemlis", 1000));

            User user = new User("Isak", "Jensen", "Hemlis123", 2001);
            user.BankAccounts.Add(new PersonalAccount(10000));
            bank.BankAccounts.Add(10000, 2001);
            user.BankAccounts[0].AccountName = "Personkonto";
            user.BankAccounts[0].CurrencySign = "kr";
            user.BankAccounts[0].AddBalance(10000);
            bank.CurrencyExRate.Add("USD", 9.11m);


            user.BankAccounts.Add(new PersonalAccount(10001));
            bank.BankAccounts.Add(10001, 2001);
            user.BankAccounts[1].AddBalance(10000);
            user.BankAccounts[1].CurrencySign = "kr";
            user.BankAccounts[1].AccountName = "Personkonto";
            bank.Persons.Add(user);

            ForeignAccount f1 = new ForeignAccount(10003);
            f1.CurrencySign = "$";
            user.BankAccounts.Add(f1);
            bank.BankAccounts.Add(10003, 2001);
            user.BankAccounts[2].AccountName = "Konto i Amerikanska dollar";
            user.BankAccounts[2].AddBalance(10000);

            User user2 = new User("Edwin", "Westerberg", "Hemlis1234", 2002);
            user2.BankAccounts.Add(new PersonalAccount(10002));
            bank.BankAccounts.Add(10002, 2002);
            user2.BankAccounts[0].AccountName = "Personkonto";

            user2.BankAccounts[0].CurrencySign = "kr";
            user2.BankAccounts[0].AddBalance(10000);
            bank.Persons.Add(user2);
            bank.Persons.Add(new User("Mattias", "Kokkonen", "Hemlis12345", 2003));
            bank.Persons.Add(new User("Jenny", "Lund-Kallberg", "Hemlis123456", 2005));
        }
    }
}
