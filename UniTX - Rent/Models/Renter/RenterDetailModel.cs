using RentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniTX___Rent.Models.Renter
{
    public class RenterDetailModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string RentCardId { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public decimal OverdueFees { get; set; }
        public IEnumerable<Rent> TXRented { get; set; }
        public IEnumerable<RentHistoryModel> RentHistory { get; set; }
        public IEnumerable<Hold> Holds { get; set; }
    }
    public class RentHistoryModel
    {
        public string TXTitle { get; set; }
        public string RentedOut { get; set; }
        public string Returned { get; set; }
        public decimal LateFine { get; set; }
    }
}
