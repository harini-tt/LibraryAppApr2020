using System;
namespace LibraryApp
{
    static class LibraryAcc
    {
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
            return account;
        }
    }
}
