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
        public Admin(string firstName, string lastName, string passWord, int AdminId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PassWord = passWord;
            this.UserId = AdminId;

        }
        public decimal CurrencyUpdate(Dictionary<string, decimal> currency)
        {
            Console.Clear();
            bool answer = false;
            decimal upDatedUSD;

            Console.WriteLine($"\nAktuell kurs för USD: {currency["USD"]}");

            Console.WriteLine($"\nVill du ändra kursen? \n\n1. Ja \n\n2. Nej\n");
            do
            {

                string input = Console.ReadLine().ToUpper();
                if (input == "1" || input == "JA")
                {
                    Console.Clear();
                    Console.Write("\nAnge dagskursen för 1 USD till SEK: ");

                    try
                    {
                        upDatedUSD = Convert.ToDecimal(Console.ReadLine());

                        currency["USD"] = upDatedUSD;
                        Console.Clear();

                        this.UpdateLog($"Uppdaterad kurs för USD: {currency["USD"]}");
                        Console.WriteLine($"\nUppdaterad kurs för USD: {currency["USD"]}");
                        answer = true;
                        Console.WriteLine("\nTryck på valfri tangent för att komma tillbaka till menyn.");
                        Console.ReadKey();
                        Console.Clear();
                        return upDatedUSD;
                    }
                    catch
                    {
                        Console.WriteLine("\nFelaktigt format. Kursen får endast anges i siffror och med decimaltecken (,).");
                        Console.WriteLine("\nTryck 1 för att ändra kursen. Tryck 2 för att komma tillbaks till menyn.");
                    }
                }
                else if (input == "2" || input == "NEJ")
                {
                    Console.Clear();
                    Console.WriteLine("\nAktuell kurs: " + currency["USD"]);
                    Console.WriteLine("\nTryck på valfri tangent för att komma tillbaka till menyn.");
                    Console.ReadKey();
                    Console.Clear();
                    return currency["USD"];
                }

                else
                {
                    Console.WriteLine("\nOgiltigt svar. Tryck 1 för att ändra kursen. Tryck 2 för att komma tillbaks till menyn.");
                }
            } while (answer == false);
            return 1;
        }
    }
}
