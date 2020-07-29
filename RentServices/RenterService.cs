using Microsoft.EntityFrameworkCore;
using RentData;
using RentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentServices
{
    public class RenterService : IRenter
    {
        private RentContext _context;

        public RenterService(RentContext context)
        {
            _context = context;
        }
        public void Add(Renter newRenter)
        {
            _context.Add(newRenter);
            _context.SaveChanges();
        }

        public Renter Get(string cardId)
        {
            return _context.Renters
                .Include(r => r.RentCard)
                .FirstOrDefault(r => r.RentCard.CardId == cardId);
        }

        public IEnumerable<Hold> GetHolds(string cardId)
        {
            return _context.Holds
                .Include(h => h.RentCard)
                .Include(h => h.Textbook)
                .Where(h => h.RentCard.CardId == cardId);
        }

        public decimal GetLateFine(int rhId)
        {
            var rentHis = _context.RentHistories
                .FirstOrDefault(rh => rh.Id == rhId);

            var dueDate = rentHis.RentedOut.AddDays(30);

            decimal lateFine = 0;
            
            if(rentHis.Returned.ToString() != "0001-01-01 00:00:00.0000000")
            {
                if(rentHis.Returned <= dueDate)
                {
                    return lateFine;
                }
                else
                {
                    lateFine = rentHis.Returned.Subtract(dueDate).Days;
                    return lateFine;
                }
            }
            else
            {
                return lateFine;
            }
        }

        public IEnumerable<RentHistory> GetRentHistory(int renterId)
        {
            return _context.RentHistories
                .Include(rh => rh.Renter)
                .Include(rh => rh.Textbook)
                .Where(rh => rh.Renter.Id == renterId);
        }

        public IEnumerable<Rent> GetRents(string cardId)
        {
            return _context.Rents
                .Include(r => r.RentCard)
                .Include(r => r.Textbook)
                .Where(r => r.RentCard.CardId == cardId);
        }

        public string GetTXTitle(int rhId)
        {
            var rentHis = _context.RentHistories
                .Include(rh => rh.Textbook)
                .FirstOrDefault(rh => rh.Id == rhId);

            return _context.Textbooks
                .FirstOrDefault(tx => tx.Id == rentHis.Textbook.Id).Title;
        }

        public void linkRC(Renter renter, RentCard rentcard)
        {
            _context.Update(renter);
            renter.RentCard = rentcard;
            _context.SaveChanges();
        }
    }
}
