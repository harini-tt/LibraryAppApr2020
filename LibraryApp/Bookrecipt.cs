using System;
namespace LibraryApp
{
    public class Bookrecipt
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int AccountNumber { get; set; }
    }
}
