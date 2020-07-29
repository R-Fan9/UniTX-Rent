using RentData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace RentData
{
    public interface IRent
    {
        IEnumerable<Rent> GetAll();
        Rent GetById(int rentId);
        void Add(Rent newRent);
        void RentItem(int bookId, string CardId);
        void ReturnItme(int bookId, string CardId);
        IEnumerable<RentHistory> GetRentHistory(int id);
        void PlaceHold(int bookId, string CardId);
        string GetCurrentHoldRenterName(int id);
        IEnumerable<Renter> GetCurrentRenters(int id);
        DateTime GetCurrentHoldPlaced(int id);
        IEnumerable<Hold> GetCurrentHolds(int id);
    }
}
