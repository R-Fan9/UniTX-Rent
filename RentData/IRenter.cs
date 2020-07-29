using RentData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentData
{
    public interface IRenter
    {
        Renter Get(string cardId);
        void Add(Renter newRenter);
        IEnumerable<Rent> GetRents(string cardId);
        IEnumerable<Hold> GetHolds(string cardId);
        IEnumerable<RentHistory> GetRentHistory(int renterId);
        string GetTXTitle(int rhId);
        decimal GetLateFine(int rhId);
        void linkRC(Renter renter, RentCard rentcard);

    }
}
