using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FoxyBank.Test
{
    [TestClass]
    public class FoxyBankTest
    {
        [TestMethod]
        [Description("This is to check if login is valid" + "when password is"+ "Hemlis123" + "and userID is 2001")]

        public void Login_Is_Valid_When_UserId_Is_2001_And_Password_Is_Hemlis123()
        {
            Bank ourBank = new Bank();
            User user = new User("Isak", "Jensen", "Hemlis123", 2001);

            var actual = user.Authentication("Hemlis123", 2001);
            var expected = true;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        [Description("This test is to check deposit" + "100 kr from userID 2001 to accountnr 10000")]
        public void Deposit_Of_100_Kr_To_AccountNr_10000()
        {
            Bank ourBank = new Bank();

            User user = new User("Isak", "Jensen", "Hemlis123", 2001);
            user.BankAccounts.Add(new PersonalAccount(10000));
            ourBank.BankAccounts.Add(10000, 2001);
            user.BankAccounts[0].AddBalance(100);            
            var actual = user.BankAccounts[0].GetBalance();            
            var expected = 100;
            Assert.AreEqual(actual, expected);
        }
    }
}
