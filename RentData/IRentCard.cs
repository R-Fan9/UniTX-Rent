using RentData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentData
{
    public interface IRentCard
    {
        void Add(RentCard newRentCard);
        bool checkCardId(string cardId);
    }
}
