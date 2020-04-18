using System;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myFirstAccount = LibraryAcc.CreateAccount("Bob Smith", "smithb", TypesofAccounts.Teen, 9999, "bob.smith@test.com", 1234567890);
            myFirstAccount.CheckoutBook(2);
            // myFirstAccount.CheckoutMovie(1);
            // myFirstAccount.CheckoutMagazine(6);
            Console.WriteLine($"AN: {myFirstAccount.AccountNumber}, Name: {myFirstAccount.UserName}, Account Type: {myFirstAccount.AccountType}, Email: {myFirstAccount.EmailAddress}, Phone: {myFirstAccount.PhoneNumber}, Created Date: {myFirstAccount.CreatedDate}, Books Balance: {myFirstAccount.BooksBalance}");

            var mySecondAccount = LibraryAcc.CreateAccount("Melissa Jones","jonesm", TypesofAccounts.Adult, 8181, "melissa.jones@test.com", 0987654321);
            mySecondAccount.ReturnBook(2);
            mySecondAccount.CheckoutBook(10);
            // mySecondAccount.CheckoutMovie(1);
            // mySecondAccount.CheckoutMagazine(6);
            Console.WriteLine($"AN: {mySecondAccount.AccountNumber}, Name: {mySecondAccount.UserName}, Account Type: {mySecondAccount.AccountType}, Email: {mySecondAccount.EmailAddress}, Phone: {mySecondAccount.PhoneNumber}, Created Date: {mySecondAccount.CreatedDate}, Books Balance: {mySecondAccount.BooksBalance}");

        }
    }
}
