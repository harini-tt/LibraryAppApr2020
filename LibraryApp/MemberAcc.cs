using System;
namespace LibraryApp
{
    enum TypesofAccounts
    {
        Toddler,
        Kid,
        Teen,
        Adult,
        Senior
    }

    class MemberAcc
    {

        #region Properties
        public int AccountNumber { get; private set; }
        public TypesofAccounts AccountType { get; set; }
        public string EmailAddress { get; set; }
        public int PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string MemberName { get; set; }
        public int PinNumber { get; set; }
        public int BooksBalance { get;  private set; }
        // public int MovieBalance { get; private set; }
        // public int MagazineBalance { get; private set; }
        public DateTime CreatedDate { get; set; }
        #endregion

        #region Constructor
        public MemberAcc()
        {
            CreatedDate = DateTime.Now;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add money
        /// </summary>
        /// <param name="bookamount">Amount to add</param>
        /// <param name="movieamount"></param>
        /// <param name="magazineamount"></param>
        public int CheckoutBook(int bookamount)
        {
            BooksBalance += bookamount;
            return BooksBalance;
        }
        public int ReturnBook(int bookamount)
        {
            BooksBalance -= bookamount;
            return BooksBalance;
        }


        /*
         * public int CheckoutMovie(int movieamount)
        {
            MovieBalance += movieamount;
            return MovieBalance;
        }
        public int ReturnMovie(int movieamount)
        {
            MovieBalance -= movieamount;
            return MovieBalance;
        }
        public int CheckoutMagazine(int magazineamount)
        {
            MagazineBalance += magazineamount;
            return MagazineBalance;
        }
        public int ReturnMagazine(int magazineamount)
        {
            MagazineBalance -= magazineamount;
            return MagazineBalance;
        }
        */
        #endregion
        
    }
}
