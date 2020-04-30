using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp
{
    static class LibraryAcc
    {
        private static List<MemberAcc> accounts = new List<MemberAcc>();
        private static List<Bookrecipt> transactions = new List<Bookrecipt>();
        /// <summary>
        /// member info
        /// </summary>
        /// <param name="memberName"></param>
        /// <param name="userName"></param>
        /// <param name="emailAddress"></param>
        /// <param name="accountType"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="pinNumber"></param>
        /// <returns></returns>
        public static MemberAcc CreateAccount(string memberName, string userName, TypesofAccounts accountType, int pinNumber, string emailAddress, int phoneNumber)
        {
            var account = new MemberAcc
            {
                MemberName = memberName,
                UserName = userName,
                AccountType = accountType,
                PinNumber = pinNumber,
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber
            };
            accounts.Add(account);
            return account;
        }
        // read only
        public static IEnumerable<MemberAcc> GetAccounts(int phoneNumber)
        {
            return accounts.Where(a => a.PhoneNumber == phoneNumber);
        }
        public static IEnumerable<Bookrecipt> GetAccountHistory(int accountNumber)
        {
            return transactions
                .Where(h => h.AccountNumber == accountNumber)
                .OrderByDescending(h => h.TransactionDate);
        }
        public static void Return(int accountNumber, int bookamount)
        {
            // locate the account
            var account = accounts.SingleOrDefault(account => account.AccountNumber == accountNumber);
            if (account == null)
                return;
            // return on account
            account.ReturnBook(bookamount);
            // add a transaction
            var transaction = new Bookrecipt
            {
                TransactionDate = DateTime.Now,
                Description = "Return Books",
                Amount = bookamount,
                AccountNumber = accountNumber
            };
            transactions.Add(transaction);
        }
        public static void Checkout(int accountNumber, int bookamount)
        {
            // locate the account
            var account = accounts.SingleOrDefault(account => account.AccountNumber == accountNumber);
            if (account == null)
                return;
            // return on account
            account.CheckoutBook(bookamount);
            // add a transaction
            var transaction = new Bookrecipt
            {
                TransactionDate = DateTime.Now,
                Description = "Checkout Books",
                Amount = bookamount,
                AccountNumber = accountNumber
            };
            transactions.Add(transaction);
        }
    }
}
