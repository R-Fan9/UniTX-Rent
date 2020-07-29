using RentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace UniTX___Rent.Models.Textbook
{
    public class TextbookDetailModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
        public string ImageUrl { get; set; }
        public int NumberOfCopies { get; set; }
        public int NumberOfRentOuts { get; set; }
        public IEnumerable<RentHistory> RentHistory { get; set; }
        public IEnumerable<BookHoldModle> CurrentHolds { get; set; }
        public IEnumerable<CurrentRentersModel> CurrentRenters { get; set; }

    }

    public class CurrentRentersModel
    {
        public string RenterName { get; set; }
    }

    public class BookHoldModle
    {
        public string RenterName { get; set; }
        public string HoldPlaced { get; set; }
    }
}
