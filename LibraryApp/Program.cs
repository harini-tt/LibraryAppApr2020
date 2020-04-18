using System;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myFirstAccount = new Account();
            myFirstAccount.AccountNumber = 990;
            myFirstAccount.UserName = "harini";
            myFirstAccount.EmailAddress = "harini@test.com";
            myFirstAccount.PhoneNumber = 1234567890;
            myFirstAccount.Return(1);
            myFirstAccount.Checkout(2);

            var mySecondAccount = new Account();
            mySecondAccount.AccountNumber = 123;
            mySecondAccount.UserName = "harinitt";
            mySecondAccount.EmailAddress = "harinitt@test.com";
            mySecondAccount.PhoneNumber = 2345678901;
            mySecondAccount.Return(2);
            mySecondAccount.Checkout(1);

        }
    }
}
