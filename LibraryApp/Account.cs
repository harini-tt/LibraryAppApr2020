using System;
namespace LibraryApp
{
    class Account
    {
        #region Properties
        public int AccountNumber { get; set; }
        public string EmailAddress { get; set; }
        public int PhoneNumber { get; set; }
        public string UserName { get; set; }
        public int BooksBalance { get; set; }
        public DateTime CreatedDate { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Add money
        /// </summary>
        /// <param name="amount">Amount to add</param>
        public int Checkout(int amount)
        {
            BooksBalance += amount;
            return BooksBalance;
        }
        public int Return(int amount)
        {
            BooksBalance -= amount;
            return BooksBalance;
        }
        #endregion
    }
}
