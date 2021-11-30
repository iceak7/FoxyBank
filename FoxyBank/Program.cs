using System;

namespace FoxyBank
{
    class Program
    {
        static void Main(string[] args)
        {


            Bank ourBank = new Bank();
            ourBank.Persons.Add(new Admin());

            User user = new User("Isak", "Jensen", "Hemlis123", 2001);
            user.BankAccounts.Add(new PersonalAccount(10000));
            ourBank.BankAccounts.Add(10000, 2001);
            user.BankAccounts[0].AddBalance(10000);

            user.BankAccounts.Add(new PersonalAccount(10002));
            ourBank.BankAccounts.Add(10001, 2001);
            user.BankAccounts[1].AddBalance(10000);
            ourBank.Persons.Add(user);

            User user2 = new User("Edwin", "Westerberg", "Hemlis1234", 2002);
            user2.BankAccounts.Add(new PersonalAccount(10001));
            ourBank.BankAccounts.Add(1002, 2002);
            user2.BankAccounts[0].AddBalance(10000);
            ourBank.Persons.Add(user2);

            ourBank.Persons.Add(new User("Mattias", "Kokkonen", "Hemlis12345", 2003));
            ourBank.Persons.Add(new User("Jenny", "Lund-Kallberg", "Hemlis123456", 2005));
            ourBank.StartApplication();

        }
    }
}
