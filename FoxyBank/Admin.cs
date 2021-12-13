using System;
using System.Collections.Generic;
using System.Text;

namespace FoxyBank
{
    public class Admin:Person
    {
        
        public Admin()
        {
            this.FirstName = "Admin";
            this.LastName = "Admin";
            this.PassWord = "Hemlis";
            this.UserId = 1001;
        }
        public Admin(string firstName, string lastName, string passWord)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PassWord = passWord;

        }
        public decimal CurrencyUpdate(Dictionary<string, decimal> currency)
        {
            Console.Clear();

            Console.WriteLine($"Aktuell kurs för USD: {currency["USD"]}");

            Console.WriteLine($"Vill du ändra kursen? \n1. Ja \n2. Nej");

            string input = Console.ReadLine().ToUpper();
            if (input == "1" || input == "JA")
            {
                Console.Clear();
                Console.WriteLine("Ange aktuell kurs för 1 USD till SEK: ");
                decimal upDatedUSD = Convert.ToDecimal(Console.ReadLine());

                currency["USD"] = upDatedUSD;
                Console.Clear();
                this.UpdateLog($"Uppdaterad kurs för USD: {currency["USD"]}");
                Console.WriteLine($"Uppdaterad kurs för USD: {currency["USD"]}");
                return upDatedUSD;

            }
            else
            {
                Console.WriteLine(currency["USD"]);
                return currency["USD"];
            }
        }
    }
}
