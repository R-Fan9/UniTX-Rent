using RentData;
using RentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentServices
{
    public class RentCardService : IRentCard
    {
        private RentContext _context;

        public RentCardService(RentContext context)
        {
            _context = context;
        }
        public void Add(RentCard newRentCard)
        {
            _context.Add(newRentCard);
            _context.SaveChanges();
        }

        public bool checkCardId(string cardId)
        {
            return _context.RentCards
                .Where(rc => rc.CardId == cardId)
                .Any();
        }
    }
}
