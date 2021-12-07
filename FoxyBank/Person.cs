using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FoxyBank
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassWord { get; protected set; }
        public int UserId { get; protected set; }
        

        private List<string> Log = new List<string>();

        public void UpdateLog(string Updates)
        {
            string fileName = @".\LogInfo"+this.UserId;
            DateTime TimeToday = DateTime.Now;
            File.AppendAllText(fileName, "\n"+TimeToday.ToString("MM/dd/yyyy HH:mm") + " " + Updates);         //(TextWriter LG = File.CreateText(fileName))
            
            //LG.WriteLine(TimeToday.ToString("MM/dd/yyyy HH:mm") + " " + Updates);

            this.Log.Add(TimeToday.ToString("MM/dd/yyyy HH:mm")+" "+Updates);
            
            
        }
        public void DisplayLog()
        {
            Console.WriteLine("Visa log aktivitet");
            foreach (string item in Log)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Tryck på valfritangent för att fortsätta.");
            Console.ReadKey();
            Console.Clear();
        }
        public bool Authentication(string password,int userid)
        {
            if(password == this.PassWord && userid == this.UserId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }


}
