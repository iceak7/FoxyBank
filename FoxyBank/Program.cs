using System;

namespace FoxyBank
{
    class Program
    {
        static void Main(string[] args)
        {

            Bank ourBank = new Bank();
            ourBank.Persons.Add(new Admin());


            //ourBank.Persons.Add(new User("Isak", "Jensen", "Hemlis123", 2006));
            //ourBank.Persons.Add(new User("Edwin", "Westerberg", "Hemlis1234", 2002));
            //ourBank.Persons.Add(new User("Mattias", "Kokkonen", "Hemlis12345", 2003));
            //ourBank.Persons.Add(new User("Jenny", "Lund-Kallberg", "Hemlis123456", 2004));

            ourBank.StartApplication();           

        }
    }
}
