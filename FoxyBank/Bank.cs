using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace FoxyBank
{
    public class Bank
    {
        
        public List<Person> Persons { get; set; }
        public Dictionary<int, int> BankAccounts { get; set; }
        public Dictionary<string, decimal> CurrencyExRate { get; set; }

        public Bank()
        {
            this.Persons = new List<Person>();
            this.BankAccounts = new Dictionary<int, int>();
            this.CurrencyExRate = new Dictionary<string, decimal>();
        }

        public void StartApplication()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"                                                                                                    
               rg    B                         .iYj25dgQgZ5j7i                                      
              dBB  rBB                     :QBBBBBBQBBQur..                                         
             BQB2 KBBB                   .BBBBBBBBBL                                                
           7BBBBMQBBBB                  7QBBBQBQBP                                                  
          RBBBBBBBBBBB                 rQBBBBBBBR                                                   
        :QBBBBBBBB. QBBd               BBBBQBQBBR.:irvJUXI2Yvi.                                     
       SBBQBBBBBBB  EBBBBBQBBBQ.      MBQBQBBBBBQBBBBBBBPJi:..                                      
      DBBBBQBQBBBBBBBBBBBBBBBBJ       BBBBBBBQBBBQBK:                                               
     2BBBBBBBBBBBBBBBBQBBBBBP        iBBBBBBBBBBBg                                                  
     QBBBBBQBQBQBBZXRBBQM1:          LBBBBBBBBBBB                                                   
    YBQBQBBBQBBBBBP                  sBBBBBBBBQBD     ibgKUbMq.   :sPXLYv.   .v2PIr2XsvY:.   .:uUbs:
    PBBBBBBBBBBBBBBBM.               vBBBBBBBBBBB   DBBP.   :BBBS   vQBBB    .BBR. .BQBBr     rQB5. 
    LBBBQBQBBBBBQBBBQBQ.             LBBBBBBQBBBB :BBB.       1BBB    vBBBi 2BR      iBBQu   sBB    
     QBQBQBQBBBBBQBBBBBBR            LBBBBBBBBBBM BQBQ         BBBB     ZBBBB          QBQQ RQK     
     7BBBBBBBBQBBBBBBBQBBBD          jBBBBBBBBBBE BBBd         BBBQ      BBBB.          rBQBQ.      
      LBBBBQBBBBBBBQBBBQBBBBd        YBBBBBBBBBBQ BBBB         BBB2    DBX.BBQg          BBBZ       
       BBBQBQBBBQBQBQBQBBBQBBB5      JQBBBBBBBBBB  QBBR       BBQu   jBB.   jBQBr        BBBR       
       BBBBQBQBQBQBBBBBQBBBBBBBB:    YBBBQBBBQBBQ    LBBj:.:KBBs  .XBBB      BBBBBr.    .BBBB.      
       BBBBBBBQBBBBBQBQBBBQBQBBBBj   JBBBBBBBBBBJ .:..:sdMgMv     ..              .  :uB2    .      
       BBBBQBBBBBBBQBQBBBBBBBBBQBBY  LBBBBBBBBBB.   BBr    :QBK                       DBU           
       BBBBBBBBSBBBBBBBBBBBBQBQBQBB  LBBBBBBQBQB    BB       BBb    ...         ..    :BJ     ..    
       BBBBBBB  BBBBBBBQBQBQBQBQBBBM 7BBBBBBBQB     BQ:    .SBZ  .BB:.7BM :gBQi5dQBS  rQJ  .BQs:    
       BBBQBI   BBBBBBBBBBBBBBBBBBBB iBBBBBBBB:     QB1rvL5BBB.  .Q.   BB  :BB    BB  iBL sv.       
      dQBBB.    .BBBBBBBBQBBBBBBBQBB :BBBQBBB:      BB       DBB   vL: QB  .BX    MQ. rBSBB:        
  .vuBBBB1   :Lv:RBBQBBBBBBBBBBBBBBB.:BBBBBb        BB       UBB DB:   BQ  .Bq    MB  :Br YBB.      
 7BBBBBX    BBBBBQRgggMgMgMgMgggggQB  BDU.         .BB7.:::rbQL  YBDi:.PBs.rBZ    BQ: 1Q5   BBE.  ");

            Console.ForegroundColor = ConsoleColor.Red; 
            
            Console.WriteLine("\n\t\t\t* * * * * * * * * * * * * * * * * * * * * * * * * *"+
                             "\n\t\t\t*                                                 *" +
                             "\n\t\t\t*          Välkommen till Foxy Bank               *" +
                             "\n\t\t\t*                                                 *" +
                             "\n\t\t\t* * * * * * * * * * * * * * * * * * * * * * * * * *");

            Thread.Sleep(2000);

            Console.ForegroundColor = ConsoleColor.White;

            Person loggedInPerson = Login();         

        }
        public Person Login()
        {
            byte Tries = 3;
            bool Answer = false;
            int AnId;
            do
            {
                do
                {
                    Console.WriteLine("\nSkriv ditt användarID");
                    Answer = int.TryParse(Console.ReadLine(), out AnId);
                    if (Answer == false && Tries != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("\nOgiltigt användarID, försök igen.");
                        Tries--;
                    }
                    if (Tries == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("\nMisslyckad inloggning.");


                        return null;
                    }

                } while (Answer == false && Tries != 0);

                Console.WriteLine("\nSkriv in lösenord");
                string AnPassword = HidePassWord();

                foreach (Person A1 in Persons)
                {
                    if (A1.Authentication(AnPassword, AnId))
                    {
                        Console.Clear();
                        A1.UpdateLog("Loggat in.");
                        char firstDigit = A1.UserId.ToString()[0];
                        if (firstDigit == '1')              //All users with Admin function has an ID which starts with nr 1
                        {
                            RunAdminMenu((Admin)A1);
                            return null;
                        }
                        else
                        {
                            RunUserMenu((User)A1);
                            return null;
                        }
                    }
                }
                Tries--;
                Console.WriteLine("\nMisslyckad inloggning.");
            } while (Tries != 0);
            return null;
        }
        public string HidePassWord()
        {
            string password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }

            } while (key != ConsoleKey.Enter);

            return password;

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
                Console.WriteLine($"\nInloggad som: {loggedInPerson.FirstName} {loggedInPerson.LastName}. Vad vill du göra?");
                Console.WriteLine("\n\n1. Skapa ny bankkund" +
                            "\n\n2. Ändra valutakurs" +
                            "\n\n3. Visa log" +
                            "\n\n4. Logga ut" +
                            "\n\n5. Avsluta programmet\n");
                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        RegisterNewUser(loggedInPerson);
                        break;

                    case "2":                        
                        loggedInPerson.CurrencyUpdate(CurrencyExRate);                       
                        break;

                    case "3":
                        loggedInPerson.DisplayLog();

                        break;

                    case "4":
                        isRunning = false;
                        StartApplication();                        
                        break;

                    case "5":
                        isRunning = false;
                        break;
                    
                    default:
                        Console.Clear();
                        Console.WriteLine("\nOgiltigt val.");
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
                Console.WriteLine($"\nInloggad som: {loggedInPerson.FirstName} {loggedInPerson.LastName}. Vad vill du göra?");
                Console.WriteLine("\n\n1. Se dina konton och saldo" +
                        "\n\n2. Överföra pengar" +
                        "\n\n3. Skapa nytt bankkonto" +
                        "\n\n4. Ta ett lån" +
                        "\n\n5. Visa log" +
                        "\n\n6. Sätta in pengar" +
                        "\n\n7. Logga ut" +
                        "\n\n8. Avsluta programmet\n");


                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        loggedInPerson.UpdateLog("Visat alla konton.");
                        loggedInPerson.DisplayAllAccounts();
                        Console.WriteLine("\nTryck på valfri tangent för att komma vidare.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        TransferMoney(loggedInPerson);
                        break;

                    case "3":
                        CreateAccount(loggedInPerson);
                        break;

                    case "4":
                        TakeLoan(loggedInPerson);
                        break;

                    case "5":
                        loggedInPerson.DisplayLog();
                        break;

                    case "6":
                        DepositMoney(loggedInPerson);
                        break;

                    case "7":
                        loggedInPerson.UpdateLog("Loggat ut.");
                        isRunning = false;
                        StartApplication();
                        break;

                    case "8":
                        loggedInPerson.UpdateLog("Stängt ner programmet.");
                        isRunning = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Ogiltigt val.");
                        break;
                }
            }
            while (isRunning != false);
        }
        public void RegisterNewUser(Admin loggedInPerson)
        {

            Console.Clear();
            Console.WriteLine("\nVar god skriv in användarens förnamn");
            string firstNameInput = Console.ReadLine();
            Console.WriteLine("\nVar god skriv in användarens efternamn");
            string lastNameInput = Console.ReadLine();
            string passWordInput;
            bool PassHasDigit;
            string passWordCheck;
            do
            {
                do
                {
                    Console.WriteLine("\nVar god skriv in användarens lösenord. Lösenordet måste minst ha 8 bokstäver och en siffra.");

                    passWordInput = HidePassWord();
                    PassHasDigit = passWordInput.Any(char.IsDigit);
                    if (PassHasDigit == false)
                    {
                        Console.WriteLine("\nLösenordet måste innehålla minst en siffra.");
                    }
                    if (passWordInput.Length < 8)
                    {
                        Console.WriteLine("\nLösenordet är för kort.");
                    }

                } while (passWordInput.Length < 8 || PassHasDigit == false);
                passWordCheck = passWordInput;

                Console.WriteLine("\nSkriv lösenordet igen.");
                passWordCheck = HidePassWord();
                if (passWordCheck != passWordInput)
                {
                    Console.WriteLine("\nLösenordet är inte samma.");

                }
            } while (passWordCheck != passWordInput);


            User newBankUser = new User(firstNameInput, lastNameInput, passWordInput, GenerateUserID());
            this.Persons.Add(newBankUser);
            newBankUser.UpdateLog("Ditt användar konto har skapats.");
            loggedInPerson.UpdateLog($"Skapat en ny användare. ID : {newBankUser.UserId}");
            Console.Clear();
            Console.WriteLine("\nNy användare tillagd.");
            Console.WriteLine("\nAnvändarinfo");
            Console.WriteLine("Namn : {0} {1}", newBankUser.FirstName, newBankUser.LastName);
            Console.WriteLine("Lösenord : {0}", newBankUser.PassWord);
            Console.WriteLine("ID : {0}", newBankUser.UserId);

            Console.WriteLine("\nTryck på valfri tangent för att komma vidare.");
            Console.ReadKey();
            Console.Clear();
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
            Console.Clear();

            Console.WriteLine("Vad vill du öppna för konto?");
            do
            {
                Console.WriteLine("\n1. Sparkonto");
                Console.WriteLine("\n2. Personkonto");
                Console.WriteLine("\n3. Lånekonto");
                Console.WriteLine("\n4. Konto i Amerikanska dollar\n");

                string answer = Console.ReadLine();

                if (answer == "1")
                {
                    
                    SavingAccount S = new SavingAccount(GenerateAccountNr());
                    user.BankAccounts.Add(S);
                    this.BankAccounts.Add(S.AccountNr, user.UserId);
                    S.AccountName = "Sparkonto";
                    user.UpdateLog("Skapat ett " + S.AccountName + " med kontonummer : " + S.AccountNr);
                    Console.WriteLine($"\nGrattis! Du har skapat ett " + S.AccountName + " med kontonummer: " + S.AccountNr);
                    Console.Write("Räntan är " + S.GetInterest() + "%");
                    S.CurrencySign = "kr";
                    createdAccount = S;

                }

                else if (answer == "2")
                {
                    PersonalAccount P = new PersonalAccount(GenerateAccountNr());
                    user.BankAccounts.Add(P);
                    this.BankAccounts.Add(P.AccountNr, user.UserId);
                    P.AccountName = "Personkonto";
                    user.UpdateLog("Skapat ett " + P.AccountName + " med kontonummer : " + P.AccountNr);
                    Console.WriteLine($"\nGrattis! Du har skapat ett " + P.AccountName + " med kontonummer: " + P.AccountNr);
                    P.CurrencySign = "kr";
                    createdAccount = P;
                }

                else if (answer == "3")
                {
                    
                    LoanAccount L1 = new LoanAccount(GenerateAccountNr());
                    user.BankAccounts.Add(L1);
                    this.BankAccounts.Add(L1.AccountNr, user.UserId);
                    L1.AccountName = "Lånekonto";
                    user.UpdateLog("Skapat ett " + L1.AccountName + " med kontonummer : " + L1.AccountNr + " och ränta på " + L1.GetInterest());
                    Console.WriteLine($"\nGrattis! Du har skapat ett " + L1.AccountName + " med kontonummer: " + L1.AccountNr + " och ränta på " + L1.GetInterest() + "%");
                    L1.CurrencySign = "kr";
                    createdAccount = L1;
                    
                }

                else if (answer == "4")
                {
                    ForeignAccount F = new ForeignAccount(GenerateAccountNr());
                    user.BankAccounts.Add(F);
                    this.BankAccounts.Add(F.AccountNr, user.UserId);
                    F.AccountName = "Konto i Amerikanska dollar";
                    Console.WriteLine($"\nGrattis! Du har skapat ett " + F.AccountName + " med kontonummer : " + F.AccountNr);
                    user.UpdateLog("Skapat ett " + F.AccountName + " med kontonummer : " + F.AccountNr);
                    F.CurrencySign = "$";
                    createdAccount = F;
                }

                else
                {
                    Console.WriteLine("Vänligen välj vilket typ av konto du vill öppna. Ange ett nummer från menyn.");
                }

            } while (createdAccount == null);         
            Console.WriteLine("\nTryck valfri tangent för att komma vidare.");
            Console.ReadKey();
            Console.Clear();
        }
        public bool TransferMoney(User user)
        {
            int transferFromAcc = 0;
            BankAccount fromAcc = null;
            BankAccount toAcc = null;
            Console.Clear();

            if (user.BankAccounts.Count != 0)
            {
                user.DisplayAllAccounts();

                Console.WriteLine("\nVilket konto vill du överföra pengar ifrån? Skriv kontonumret.");
                do
                {
                    int inputAcc = 0;

                    if (int.TryParse(Console.ReadLine(), out inputAcc))
                    {
                        fromAcc = user.BankAccounts.Find(x => x.AccountNr == inputAcc);
                        if (fromAcc != null)
                        {
                            if (!(fromAcc is LoanAccount))

                            {
                                if (fromAcc.GetBalance() > 0)
                                {
                                    transferFromAcc = fromAcc.AccountNr;

                                }
                                else
                                {
                                    Console.WriteLine("Konto du valde har inte tillräckligt högt saldo. Vänligen välj ett annat konto.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ogiligt val. Du kan inte välja ett lånekonto. Försök igen.");
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
                User transferToUser = null;
                Console.WriteLine("\nVilket konto vill du överföra pengar till? Skriv kontonumret.");
                Console.WriteLine("Skriv \"avbryt\" för att avbryta och återvända till menyn.");

                do
                {
                    string input = Console.ReadLine();
                    int inputAcc = 0;
                    if (int.TryParse(input, out inputAcc))
                    {
                        toAcc = user.BankAccounts.Find(x => x.AccountNr == inputAcc);
                        if (transferFromAcc == inputAcc)
                        {
                            Console.WriteLine("\nVänligen välj ett annat konto än det du ska överför pengar ifrån.");
                            Console.WriteLine("Skriv \"avbryt\" för att avbryta och återvända till menyn.");
                        }
                        else if (toAcc is LoanAccount)
                        {
                            Console.WriteLine("\nOgiltigt val. Du kan inte välja ett lånekonto. Försök igen");
                            Console.WriteLine("Skriv \"avbryt\" för att avbryta och återvända till menyn.");
                        }
                        else if (this.BankAccounts.ContainsKey(inputAcc))
                        {

                            if (this.BankAccounts[inputAcc] != user.UserId)
                            {
                                transferToUser = (User)this.Persons.Find(x => x.UserId == this.BankAccounts[inputAcc]);

                                Console.WriteLine($"\nKontot du valde med kontonummer {inputAcc} tillhör {transferToUser.FirstName} {transferToUser.LastName}." +
                                    $"\nÄr du säker att du vill överföra pengar till detta konto? Svara \"Ja\" isåfall. Tryck på valfri tangent för att ändra kontonumret.");

                                if (Console.ReadLine().ToUpper() == "JA")
                                {
                                    transferToAcc = inputAcc;
                                }
                                else
                                {
                                    Console.WriteLine("\nVänligen skriv kontonumret på kontot du vill överföra pengar till.");
                                    Console.WriteLine("Skriv \"avbryt\" för att avbryta och återvända till menyn.");
                                }
                            }
                            else
                            {
                                transferToAcc = inputAcc;
                                transferToUser = user;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInget konto med det kontonummer du matade in hittades. Vänligen testa att skriva kontonumret igen.");
                            Console.WriteLine("Skriv \"avbryt\" för att avbryta och återvända till menyn.");
                        }
                    }
                    else if (input.ToUpper() == "AVBRYT")
                    {
                        Console.Clear();
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("\nVänligen mata in ett korrekt kontonummer. Vänligen testa att skriva kontonumret igen.");
                        Console.WriteLine("Skriv \"avbryt\" för att avbryta och återvända till menyn.");
                    }
                } while (transferToAcc == 0);


                decimal amountOfMoneyToTransfer = 0;

                int indexOfTransferFromAcc = user.BankAccounts.IndexOf(user.BankAccounts.Find(x => x.AccountNr == transferFromAcc));

                if (fromAcc is ForeignAccount)
                {
                    Console.WriteLine($"\nHur mycket pengar vill du överföra från {transferFromAcc} till {transferToAcc}? " +
                        $"Du har $ {user.BankAccounts[indexOfTransferFromAcc].GetBalance():f2} tillgängligt.");
                }
                else
                {
                    Console.WriteLine($"\nHur mycket pengar vill du överföra från {transferFromAcc} till {transferToAcc}? " +
                        $"Du har {user.BankAccounts[indexOfTransferFromAcc].GetBalance():f2} kr tillgängligt.");
                }
                do
                {
                    decimal inputAmount = 0;
                    if (decimal.TryParse(Console.ReadLine(), out inputAmount))
                    {
                        if (inputAmount > 0 & user.BankAccounts[indexOfTransferFromAcc].GetBalance() >= inputAmount)
                        {
                            amountOfMoneyToTransfer = inputAmount;

                        }
                        else
                        {
                            Console.WriteLine("Vänligen mata in en summa som är giltig att överföra. Skriv summan som ska överföras igen.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Vänligen mata in en summa som är giltig att överföra. Skriv summan som ska överföras igen.");
                    }

                } while (amountOfMoneyToTransfer == 0);

                int triesLeft = 3;
                bool succesfulTransaction = false;

                if (toAcc is ForeignAccount && !(fromAcc is ForeignAccount))
                {
                    Console.WriteLine($"\nDu vill överföra {amountOfMoneyToTransfer} kr från kontot med kontonummer {transferFromAcc} till kontonummer {transferToAcc}." +
                        $"\nVänligen mata in ditt lösenord för att genomföra transaktionen.");

                }
                else if (fromAcc is ForeignAccount && !(toAcc is ForeignAccount))
                {
                    Console.WriteLine($"\nDu vill överföra $ {amountOfMoneyToTransfer} från kontot med kontonummer {transferFromAcc} till kontonummer {transferToAcc}." +
                      $"\nVänligen mata in ditt lösenord för att genomföra transaktionen.");
                }
                else if (fromAcc is ForeignAccount && toAcc is ForeignAccount)
                {
                    Console.WriteLine($"\nDu vill överföra $ {amountOfMoneyToTransfer} från kontot med kontonummer {transferFromAcc} till kontonummer {transferToAcc}." +
                      $"\nVänligen mata in ditt lösenord för att genomföra transaktionen.");
                }
                else
                {
                    Console.WriteLine($"\nDu vill överföra {amountOfMoneyToTransfer} från kontot med kontonummer {transferFromAcc} till kontonummer {transferToAcc}." +
                    $"\nVänligen mata in ditt lösenord för att genomföra transaktionen.");
                }

                do
                {
                    string input = HidePassWord(); ;

                    if (user.Authentication(input, user.UserId))
                    {
                        user.BankAccounts[indexOfTransferFromAcc].SubstractBalance(amountOfMoneyToTransfer);

                        if (user.UserId == transferToUser.UserId)
                        {
                            int indexOfTransferToAcc = user.BankAccounts.IndexOf(user.BankAccounts.Find(x => x.AccountNr == transferToAcc));

                            if (fromAcc is ForeignAccount && !(toAcc is ForeignAccount))
                            {
                                user.BankAccounts[indexOfTransferToAcc].AddBalance((CurrencyExRate["USD"] * amountOfMoneyToTransfer));
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == user.UserId))] = user;
                                user.UpdateLog($"Överförde $ {amountOfMoneyToTransfer} från kontot med kontonummer {transferFromAcc}" +
                                    $" till {transferToAcc}.");
                                Console.WriteLine($"\nDu överförde $ {amountOfMoneyToTransfer} från kontot med kontonummer {transferFromAcc}" +
                                    $" till {transferToAcc}.");
                                Console.WriteLine($"Ditt nya saldo på kontot med kontonummer {transferFromAcc} är " +
                                    $"$ {user.BankAccounts[indexOfTransferFromAcc].GetBalance():f2} " +
                                    $"\noch ditt nya saldo på kontot med kontonummer " +
                                    $"{transferToAcc} är {user.BankAccounts[indexOfTransferToAcc].GetBalance():f2} kr.");
                                succesfulTransaction = true;
                            }
                            else if (toAcc is ForeignAccount && !(fromAcc is ForeignAccount))
                            {
                                user.BankAccounts[indexOfTransferToAcc].AddBalance((amountOfMoneyToTransfer / CurrencyExRate["USD"]));
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == user.UserId))] = user;

                                user.UpdateLog($"Överförde {amountOfMoneyToTransfer}kr från kontot med kontonummer {transferFromAcc}" +$" till {transferToAcc}.");
                                Console.WriteLine($"\n\nDu överförde {amountOfMoneyToTransfer}kr från kontot med kontonummer {transferFromAcc}" +
                                    $" till {transferToAcc}.");
                              
                                Console.WriteLine($"Ditt nya saldo på kontot med kontonummer {transferFromAcc} är " +
                                    $"{user.BankAccounts[indexOfTransferFromAcc].GetBalance():f2}kr" +
                                    $"\noch ditt nya saldo på kontot med kontonummer " +
                                    $"{transferToAcc} är {user.BankAccounts[indexOfTransferToAcc].GetBalance():f2} $.");

                                succesfulTransaction = true;
                            }

                            else if (toAcc is ForeignAccount && fromAcc is ForeignAccount)
                            {
                                user.BankAccounts[indexOfTransferToAcc].AddBalance(amountOfMoneyToTransfer);
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == user.UserId))] = user;

                                Console.WriteLine($"\nDu överförde $ {amountOfMoneyToTransfer} från kontot med kontonummer {transferFromAcc}" +
                                    $" till {transferToAcc}.");
                                user.UpdateLog($"Överförde $ {amountOfMoneyToTransfer} från kontot med kontonummer {transferFromAcc}" +$" till {transferToAcc}.");
                                Console.WriteLine($"Ditt nya saldo på kontot med kontonummer {transferFromAcc} är " +
                                    $"$ {user.BankAccounts[indexOfTransferFromAcc].GetBalance():f2} " +
                                    $"\noch ditt nya saldo på kontot med kontonummer " +
                                    $"{transferToAcc} är $ {user.BankAccounts[indexOfTransferToAcc].GetBalance():f2}.");

                                succesfulTransaction = true;
                            }
                            else
                            {
                                user.BankAccounts[indexOfTransferToAcc].AddBalance(amountOfMoneyToTransfer);
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == user.UserId))] = user;

                                Console.WriteLine($"\nDu överförde {amountOfMoneyToTransfer} kr från kontot med kontonummer {transferFromAcc}" +
                                    $" till {transferToAcc}.");
                                user.UpdateLog($"Överförde {amountOfMoneyToTransfer} kr från kontot med kontonummer {transferFromAcc}" +$" till {transferToAcc}.");
                                Console.WriteLine($"Ditt nya saldo på kontot med kontonummer {transferFromAcc} är " +
                                    $"{user.BankAccounts[indexOfTransferFromAcc].GetBalance():f2} kr " +
                                    $"\noch ditt nya saldo på kontot med kontonummer " +
                                    $"{transferToAcc} är {user.BankAccounts[indexOfTransferToAcc].GetBalance():f2} kr.");

                                succesfulTransaction = true;
                            }
                        }
                        else
                        {
                            int indexOfTransferToAcc = transferToUser.BankAccounts.IndexOf(transferToUser.BankAccounts.Find(x => x.AccountNr == transferToAcc));

                            if (fromAcc is ForeignAccount && !(toAcc is ForeignAccount))
                            {
                                transferToUser.BankAccounts[indexOfTransferToAcc].AddBalance((CurrencyExRate["USD"] * amountOfMoneyToTransfer));
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == user.UserId))] = user;
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == transferToUser.UserId))] = transferToUser;
                                user.UpdateLog($"Överförde $ {amountOfMoneyToTransfer} från kontot med kontonummer {transferFromAcc} till {transferToAcc}.");
                                Console.WriteLine($"\nDu överförde $ {amountOfMoneyToTransfer} från kontot med kontonummer {transferFromAcc} till {transferToAcc}.");
                                Console.WriteLine($"Ditt nya saldo på kontot med kontonummer {transferFromAcc} är $ {user.BankAccounts[indexOfTransferFromAcc].GetBalance():f2}");

                                succesfulTransaction = true;
                            }

                            else if (toAcc is ForeignAccount && !(fromAcc is ForeignAccount))
                            {
                                transferToUser.BankAccounts[indexOfTransferToAcc].AddBalance((amountOfMoneyToTransfer / CurrencyExRate["USD"]));
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == user.UserId))] = user;
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == transferToUser.UserId))] = transferToUser;
                                user.UpdateLog($"Överförde {amountOfMoneyToTransfer} kr från kontot med kontonummer {transferFromAcc} till {transferToAcc}.");
                                Console.WriteLine($"\nDu överförde {amountOfMoneyToTransfer} kr från kontot med kontonummer {transferFromAcc} till {transferToAcc}.");
                                Console.WriteLine($"Ditt nya saldo på kontot med kontonummer {transferFromAcc} är {user.BankAccounts[indexOfTransferFromAcc].GetBalance():f2} kr.");

                                succesfulTransaction = true;
                            }

                            else if (toAcc is ForeignAccount && fromAcc is ForeignAccount)
                            {
                                transferToUser.BankAccounts[indexOfTransferToAcc].AddBalance(amountOfMoneyToTransfer);
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == user.UserId))] = user;
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == transferToUser.UserId))] = transferToUser;
                                user.UpdateLog($"Överförde $ {amountOfMoneyToTransfer} från kontot med kontonummer {transferFromAcc} till {transferToAcc}.");
                                Console.WriteLine($"\nDu överförde $ {amountOfMoneyToTransfer} från kontot med kontonummer {transferFromAcc} till {transferToAcc}.");
                                Console.WriteLine($"Ditt nya saldo på kontot med kontonummer {transferFromAcc} är $ {user.BankAccounts[indexOfTransferFromAcc].GetBalance():f2}.");

                                succesfulTransaction = true;
                            }

                            else
                            {
                                transferToUser.BankAccounts[indexOfTransferToAcc].AddBalance(amountOfMoneyToTransfer);
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == user.UserId))] = user;
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == transferToUser.UserId))] = transferToUser;
                                user.UpdateLog($"Överförde {amountOfMoneyToTransfer}kr från kontot med kontonummer {transferFromAcc} till {transferToAcc}.");
                                Console.WriteLine($"\nDu överförde {amountOfMoneyToTransfer}kr från kontot med kontonummer {transferFromAcc} till {transferToAcc}.");
                                Console.WriteLine($"Ditt nya saldo på kontot med kontonummer {transferFromAcc} är {user.BankAccounts[indexOfTransferFromAcc].GetBalance():f2}");

                                succesfulTransaction = true;
                            }
                        }
                    }
                    else
                    {
                        triesLeft--;
                        Console.WriteLine(triesLeft > 0 ? "\nFel lösenord. Försök igen." : "\nTransaktion misslyckades. Du skrev fel lösenord för många gånger.");
                    }

                } while (triesLeft > 0 & !succesfulTransaction);
            }
            else
            {
                user.DisplayAllAccounts();
            }
            Console.WriteLine("\nTryck på valfri tangent för att komma vidare.");
            Console.ReadKey();
            Console.Clear();
            return true;
        }
        public bool TakeLoan(User user)
        {
            BankAccount Loanaccount = null;
            bool hasLoanAccount = false;
            decimal Debt = 0;
            decimal totalBalance = 0;

            foreach (var item in user.BankAccounts)
            {
                if (item is LoanAccount)
                {
                    Debt = item.GetBalance() * -1;
                    Loanaccount = item;
                    hasLoanAccount = true;
                }
                else if (item is ForeignAccount)
                {
                    string currency = "";
                    if (item.CurrencySign == "$")
                    {
                        currency = "USD";
                    }
                    decimal exchangeRate = CurrencyExRate[currency];
                    totalBalance += item.GetBalance() * exchangeRate;
                }
                else
                {
                    totalBalance += item.GetBalance();
                }
            }
            decimal loanLimit = (totalBalance - Debt) * 5;
            decimal possibleLoan = loanLimit - Debt;
            Console.Clear();
            Console.WriteLine("Ditt totala saldo är: " + totalBalance.ToString("f2") + " kr.");
            Console.WriteLine("Du kan låna upp till " + possibleLoan.ToString("f2") + " kr.");
            if (Debt > 0)
            {
                Console.WriteLine("Din skuld är: " + Debt.ToString("f2") + "kr");
                Console.WriteLine("Ditt lånetak är: " + loanLimit.ToString("f2") + " kr och du kan låna upp till " + possibleLoan.ToString("f2") + " nya kr.");

            }
            else
            {
                Console.WriteLine("Du har ingen skuld och du kan låna upp till: " + possibleLoan.ToString("f2") + " kr.");

            }

            if (hasLoanAccount == false)
            {
                Console.Clear();               

                Console.WriteLine("Du har inte något lånekonto, vill du öppna ett? Ja/Nej");
                do
                {
                    string input = Console.ReadLine().ToUpper();
                    if (input == "JA")
                    {
                        Loanaccount = new LoanAccount(GenerateAccountNr());
                        user.BankAccounts.Add(Loanaccount);
                        this.BankAccounts.Add(Loanaccount.AccountNr, user.UserId);
                        Loanaccount.AccountName = "Lånekonto";
                        Console.WriteLine($"\nGrattis! Du har skapat ett " + Loanaccount.AccountName + " med kontonummer : " + Loanaccount.AccountNr);
                        user.UpdateLog("Skapat nytt lånekonto. Kontonummer: " + Loanaccount.AccountNr);
                        hasLoanAccount = true;
                    }
                    else if (input == "NEJ")
                    {
                        Console.Clear();
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Var god skriv in Ja eller Nej för att komma vidare.");
                    }
                } while (hasLoanAccount == false);

            }
            if (possibleLoan<=0)
            {
                Console.WriteLine("\nDu kan inte låna mer pengar. Tryck valfri tangent för att komma tillbaka till menyn.");
                Console.ReadKey();
                Console.Clear();
                return false;
            }
            else
            {
                Console.WriteLine("\nHur mycket pengar vill du låna?");
                Console.WriteLine("Du kan låna upp till " + possibleLoan.ToString("f2") + " kr.");
            }
            decimal inputAmount = 0;

            bool incorrectAmount = true;
            do
            {

                string loaninput = Console.ReadLine();

                if (decimal.TryParse(loaninput, out inputAmount))
                {
                    if (inputAmount > 0 && inputAmount <= possibleLoan)
                    {

                        Console.Clear();
                        user.DisplayAllAccounts();
                        Console.WriteLine("\nDu vill låna " + inputAmount + " kr. Ange kontonumret på det konto du vill att pengarna ska placeras på.");
                        int accNum = 0;

                        bool incorrectAccNr = true;

                        do
                        {
                            string inputAcc = Console.ReadLine();
                            if (int.TryParse(inputAcc, out accNum))
                            {

                                if (user.BankAccounts.Exists(x => (x.AccountNr == accNum && !(x is LoanAccount))))
                                {
                                    int tries = 3;
                                    Console.WriteLine("\nDu vill låna: " + inputAmount + " kr. Pengarna placeras på kontonummer: " + accNum);
                                    Console.WriteLine("Var god skriv in ditt lösenord för att bekräfta transaktionen");
                                    do
                                    {
                                        string passInput = HidePassWord();
                                        Console.WriteLine();
                                        if (user.Authentication(passInput, user.UserId))
                                        {
                                            Loanaccount.SubstractBalance(inputAmount);
                                            var accountTransfer = user.BankAccounts.Find(x => x.AccountNr == accNum);
                                            if (accountTransfer is ForeignAccount)
                                            {
                                                string currency = "";
                                                if (accountTransfer.CurrencySign == "$")
                                                {
                                                    currency = "USD";
                                                }
                                                decimal exchangeRate = CurrencyExRate[currency];
                                                accountTransfer.AddBalance(inputAmount / exchangeRate);
                                                Console.Clear();
                                                Console.WriteLine("Grattis! du har tagit ett lån på " + accountTransfer.CurrencySign + (inputAmount / exchangeRate).ToString("f2") + ".");
                                                Console.WriteLine();
                                                Console.WriteLine("Pengarna fördes över till " + accountTransfer.AccountNr + " och din skuld är nu på " + (Loanaccount.GetBalance() * -1).ToString("f2") + " kr");
                                                user.UpdateLog("Ett lån har tagits på " + accountTransfer.CurrencySign + (inputAmount / exchangeRate).ToString("f2") + ". " + 
                                                    "Pengarna fördes över till " + accountTransfer.AccountNr + " och din skuld är nu på " + (Loanaccount.GetBalance() * -1).ToString("f2") + " kr");
                                            }
                                            else
                                            {
                                                accountTransfer.AddBalance(inputAmount);
                                                Console.WriteLine("Grattis! du har tagit ett lån på " + inputAmount + " kr.");
                                                Console.WriteLine();
                                                Console.WriteLine("Pengarna fördes över till " + accountTransfer.AccountNr + " och din skuld är nu på " + Loanaccount.GetBalance() * -1 + "kr");
                                                user.UpdateLog("Ett lån har tagits på " + inputAmount + "kr. Pengarna fördes över till " + accountTransfer.AccountNr + " och din skuld är nu på " + Loanaccount.GetBalance() * -1 + "kr");
                                            }

                                            Console.WriteLine("Tryck på valfri tangent för att komma tillbaks till menyn");
                                            Console.ReadKey();
                                            Console.Clear();
                                            incorrectAccNr = false;

                                            return true;
                                        }
                                        else
                                        {
                                            tries--;
                                            if (tries > 0)
                                            {
                                                Console.WriteLine("\nFel lösenord. Försök igen");
                                            }

                                        }

                                    } while (tries > 0);
                                    if (tries == 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Du skrev fel lösenord för många gånger. Tryck på valfri tangent för att komma tillbaks till menyn.");
                                        user.UpdateLog("Användaren skrev fel lösenord 3 gånger vid ett försök att ta ett lån.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        return false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Inkorrekt inmatning. Var vänlig försök igen. OBS! Du kan inte använda ditt lånekonto");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Inkorrekt inmatning. Var vänlig försök igen");
                            }
                        } while (incorrectAccNr); 
                        
                    }
                    else
                    {
                        Console.WriteLine("Ogiltig summa. Var vänlig försök igen");
                    }
                }
                else
                {
                    Console.WriteLine("Inkorrekt inmatning. Var vänlig försök igen");
                }
            } while (incorrectAmount);
            return false;
        }
        public void DepositMoney(User user)
        {
            BankAccount depositAcc = null;
            Console.Clear();

            if (user.BankAccounts.Count != 0)
            {
                user.DisplayAllAccounts();

                int depositToAcc = 0;
                User depositToUser = null;
                Console.WriteLine("\nVilket konto vill du sätta in pengar på? Skriv kontonumret.");

                do
                {
                    int inputAcc = 0;
                    if (int.TryParse(Console.ReadLine(), out inputAcc))
                    {
                        depositAcc = user.BankAccounts.Find(x => x.AccountNr == inputAcc);

                        if (this.BankAccounts.ContainsKey(inputAcc))
                        {

                            if (this.BankAccounts[inputAcc] != user.UserId)
                            {
                                depositToUser = (User)this.Persons.Find(x => x.UserId == this.BankAccounts[inputAcc]);

                                Console.WriteLine($"\nKontot du valde med kontonummer {inputAcc} tillhör {depositToUser.FirstName} {depositToUser.LastName}." +
                                    $"\nÄr du säker att du vill sätta in pengar på detta konto? Svara \"Ja\" isåfall. Tryck valfri tangent för att ändra kontonumret.");

                                if (Console.ReadLine().ToUpper() == "JA")
                                {
                                    depositToAcc = inputAcc;
                                }
                                else
                                {
                                    Console.WriteLine("Vänligen skriv kontonumret på kontot du vill överföra pengar till.");
                                }
                            }
                            else
                            {
                                depositToAcc = inputAcc;
                                depositToUser = user;
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
                } while (depositToAcc == 0);


                decimal amountOfMoneyToDeposit = 0;

                if (depositAcc is ForeignAccount)
                {
                    Console.WriteLine($"\nHur mycket pengar vill du sätta in på kontonummer {depositToAcc}? Ange summan i dollar");
                }
                else
                {
                    Console.WriteLine($"\nHur mycket pengar vill du sätta in på kontonummer {depositToAcc}?");
                }
                do
                {
                    decimal inputAmount = 0;
                    if (decimal.TryParse(Console.ReadLine(), out inputAmount))
                    {
                        if (inputAmount > 0)
                        {
                            amountOfMoneyToDeposit = inputAmount;

                        }
                        else
                        {
                            Console.WriteLine("Vänligen mata in en summa som är giltig att överföra. Skriv summan som ska överföras igen.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Vänligen mata in en summa som är giltig att överföra. Skriv summan som ska överföras igen.");
                    }

                } while (amountOfMoneyToDeposit == 0);

                int triesLeft = 3;
                bool succesfulTransaction = false;

                if (depositAcc is ForeignAccount)
                {
                    Console.WriteLine($"\nDu vill sätta in $ {amountOfMoneyToDeposit} på kontot med kontonummer {depositToAcc}." +
                        $"\nVänligen mata in ditt lösenord för att genomföra transaktionen.");
                }

                else
                {
                    Console.WriteLine($"\nDu vill sätta in {amountOfMoneyToDeposit} kr på kontot med kontonummer {depositToAcc}." +
                         $"\nVänligen mata in ditt lösenord för att genomföra transaktionen.");
                }

                do
                {
                    string input = HidePassWord(); ;

                    if (user.Authentication(input, user.UserId))
                    {
                        if (user.UserId == depositToUser.UserId)
                        {
                            int indexOfDepositToAcc = user.BankAccounts.IndexOf(user.BankAccounts.Find(x => x.AccountNr == depositToAcc));

                            if (depositAcc is ForeignAccount)
                            {
                                user.BankAccounts[indexOfDepositToAcc].AddBalance(amountOfMoneyToDeposit);
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == user.UserId))] = user;
                                user.UpdateLog($"Du satte in $ {amountOfMoneyToDeposit} på kontot med kontonummer {depositToAcc}.");
                                Console.WriteLine($"\nDu satte in $ {amountOfMoneyToDeposit} på kontot med kontonummer {depositToAcc}.");
                                Console.WriteLine($"Ditt nya saldo på kontot är $ {user.BankAccounts[indexOfDepositToAcc].GetBalance():f2}.");

                                succesfulTransaction = true;
                            }
                            else
                            {
                                user.BankAccounts[indexOfDepositToAcc].AddBalance(amountOfMoneyToDeposit);
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == user.UserId))] = user;
                                user.UpdateLog($"Du satte in {amountOfMoneyToDeposit} kr på kontot med kontonummer {depositToAcc}.");
                                Console.WriteLine($"\nDu satte in {amountOfMoneyToDeposit} kr på kontot med kontonummer {depositToAcc}.");
                                Console.WriteLine($"Ditt nya saldo på kontot är {user.BankAccounts[indexOfDepositToAcc].GetBalance():f2} kr.");

                                succesfulTransaction = true;
                            }
                        }
                        else
                        {
                            int indexOfTransferToAcc = depositToUser.BankAccounts.IndexOf(depositToUser.BankAccounts.Find(x => x.AccountNr == depositToAcc));

                            if (depositAcc is ForeignAccount)
                            {
                                depositToUser.BankAccounts[indexOfTransferToAcc].AddBalance(amountOfMoneyToDeposit);
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == user.UserId))] = user;
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == depositToUser.UserId))] = depositToUser;
                                user.UpdateLog($"Du satte in $ {amountOfMoneyToDeposit} på kontot med kontonummer {depositToAcc}.");
                                Console.WriteLine($"\nDu satte in $ {amountOfMoneyToDeposit} på kontot med kontonummer {depositToAcc}.");

                                succesfulTransaction = true;
                            }

                            else
                            {
                                depositToUser.BankAccounts[indexOfTransferToAcc].AddBalance(amountOfMoneyToDeposit);
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == user.UserId))] = user;
                                Persons[Persons.IndexOf(Persons.Find(x => x.UserId == depositToUser.UserId))] = depositToUser;
                                user.UpdateLog($"Du satte in {amountOfMoneyToDeposit} kr på kontot med kontonummer {depositToAcc}.");
                                Console.WriteLine($"\nDu satte in {amountOfMoneyToDeposit} kr på kontot med kontonummer {depositToAcc}.");

                                succesfulTransaction = true;
                            }
                        }
                    }
                    else
                    {
                        triesLeft--;
                        Console.WriteLine(triesLeft > 0 ? "\nFel lösenord. Försök igen." : "\nTransaktion misslyckades. Du skrev fel lösenord för många gånger.");
                    }

                } while (triesLeft > 0 & !succesfulTransaction);
            }
            Console.WriteLine("\nTryck på valfri tangent för att komma vidare.");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
   


