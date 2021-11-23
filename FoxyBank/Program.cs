using System;

namespace FoxyBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank ourBank = new Bank();
            ourBank.Persons.Add(new Admin());

            ourBank.StartApplication();           

        }
    }
}
