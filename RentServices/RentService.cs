using Microsoft.EntityFrameworkCore;
using RentData;
using RentData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace RentServices
{
    public class RentService : IRent
    {
        private RentContext _context;

        public RentService(RentContext context)
        {
            _context = context;
        }

        public void Add(Rent newRent)
        {
            _context.Add(newRent);
            _context.SaveChanges();
        }

        public IEnumerable<Rent> GetAll()
        {
            return _context.Rents;
        }

        public Rent GetById(int rentId)
        {
            return GetAll()
                .FirstOrDefault(r => r.Id == rentId);
        }
        public DateTime GetCurrentHoldPlaced(int id)
        {
            return _context.Holds
                .Include(h => h.Textbook)
                .Include(h => h.RentCard)
                .FirstOrDefault(h => h.Id == id)
                .HoldPlaced;
        }

        public string GetCurrentHoldRenterName(int id)
        {
            var hold = _context.Holds
                .Include(h => h.Textbook)
                .Include(h => h.RentCard)
                .FirstOrDefault(h => h.Id == id);

            var cardId = hold?.RentCard.CardId;

            var renter = _context.Renters
                .Include(r => r.RentCard)
                .FirstOrDefault(r => r.RentCard.CardId == cardId);

            return renter?.FirstName + " " + renter?.LastName;

        }

        public IEnumerable<Hold> GetCurrentHolds(int id)
        {
            return _context.Holds
                .Include(h => h.Textbook)
                .Where(h => h.Textbook.Id == id);
        }

        public IEnumerable<RentHistory> GetRentHistory(int id)
        {
            return _context.RentHistories
                .Include(rh => rh.Textbook)
                .Include(rh => rh.Renter)
                .Where(rh => rh.Textbook.Id == id);
        }

        public void PlaceHold(int bookId, string CardId)
        {
            var card = _context.RentCards
                .FirstOrDefault(c => c.CardId == CardId);

            var repHold = _context.Holds
                .Include(h => h.RentCard)
                .FirstOrDefault(h => h.RentCard.CardId == card.CardId);

            if(card != null && repHold == null)
            {
                var now = DateTime.Now;

                var book = _context.Textbooks
                    .Include(tx => tx.Status)
                    .FirstOrDefault(tx => tx.Id == bookId);



                if (book.Status.Name == "All Out")
                {
                    UpdateTXStatus(book.Id, "On Hold");
                };

                var hold = new Hold
                {
                    HoldPlaced = now,
                    Textbook = book,
                    RentCard = card
                };
                _context.Add(hold);
                _context.SaveChanges();
            }

        }

        public void RentItem(int bookId, string CardId)
        {
            var card = _context.RentCards
                .FirstOrDefault(c => c.CardId == CardId);

            if(card != null)
            {
                var now = DateTime.Now;
                var book = _context.Textbooks
                    .Include(tx => tx.Status)
                    .FirstOrDefault(tx => tx.Id == bookId);

                var renter = _context.Renters
                    .FirstOrDefault(r => r.RentCard.Id == card.Id);

                var totalCp = book.NumberOfCopies;
                var rentCp = book.NumberOfRentOuts;

                if (totalCp > rentCp)
                {
                    _context.Update(book);
                    book.NumberOfRentOuts += 1;

                    rentCp += 1;

                    if (rentCp == totalCp)
                    {
                        if (!CurrentHold(bookId).Any())
                        {
                            UpdateTXStatus(bookId, "All Out");
                        }
                        else
                        {
                            UpdateTXStatus(bookId, "On Hold");
                        }
                    }
                    else
                    {
                        if (book.Status.Name == "All In")
                        {
                            UpdateTXStatus(bookId, "Rent Out");
                        }
                    }

                    var rent = new Rent
                    {
                        Textbook = book,
                        RentCard = card,
                        Since = now,
                        Until = GetDefaultRentTime(now)
                    };

                    _context.Add(rent);

                    var rentHistory = new RentHistory
                    {
                        RentedOut = now,
                        Textbook = book,
                        Renter = renter,
                    };

                    _context.Add(rentHistory);
                    _context.SaveChanges();

                }
                else
                {
                    return;
                }

            }
            else
            {
                return;
            }
            

        }

        private IQueryable<Hold> CurrentHold(int bookId)
        {
            var currentHolds = _context.Holds
                .Include(h => h.Textbook)
                .Include(h => h.RentCard)
                .Where(h => h.Textbook.Id == bookId);
            return currentHolds;
        }

        private DateTime GetDefaultRentTime(DateTime now)
        {
            return now.AddDays(30);
        }

        public void ReturnItme(int bookId, string CardId)
        {
            var rentHistory = _context.RentHistories
                .Include(rh => rh.Renter)
                .Where(rh => rh.Textbook.Id == bookId && rh.Returned.ToString() == "0001-01-01 00:00:00.0000000")
                .FirstOrDefault(rh => rh.Renter.RentCard.CardId == CardId);


            if (rentHistory != null)
            {
                var renter = _context.Renters
                    .FirstOrDefault(r => r.Id == rentHistory.Renter.Id);

                var now = DateTime.Now;
                var book = _context.Textbooks
                    .Include(tx => tx.Status)
                    .FirstOrDefault(tx => tx.Id == bookId);

                LateFeeCalculation(bookId, CardId, now);
                RemoveExistingRent(book.Id);
                CloseExistingRentHistory(book.Id, now, renter.Id);

                var currentHolds = CurrentHold(bookId);

                var rentCp = book.NumberOfRentOuts;

                _context.Update(book);
                book.NumberOfRentOuts -= 1;

                rentCp -= 1;
                if (rentCp == 0)
                {
                    UpdateTXStatus(bookId, "All In");
                }
                else
                {
                    if (book.Status.Name == "All Out")
                    {
                        UpdateTXStatus(bookId, "Rent Out");
                    }
                }

                _context.SaveChanges();

                if (currentHolds.Any())
                {
                    RentOutToEarliestHold(bookId, currentHolds);
                }
            }
            else
            {
                return;
            }
        }

        private void LateFeeCalculation(int bookId, string cardId, DateTime now)
        {
            var rent = _context.Rents
                .Include(r => r.Textbook)
                .Include(r => r.RentCard)
                .FirstOrDefault(r => r.Textbook.Id == bookId && r.RentCard.CardId == cardId);

            if(now > rent.Until)
            {
                var card = _context.RentCards
                    .FirstOrDefault(c => c.CardId == cardId);

                var timeDiff = now.Subtract(rent.Until);

                _context.Update(card);
                card.LateFine += timeDiff.Days;
            }

        }

        private void RentOutToEarliestHold(int bookId, IQueryable<Hold> currentHolds)
        {
            var earliestHold = currentHolds.OrderBy(hold => hold.HoldPlaced).FirstOrDefault();

            var cardId = earliestHold.RentCard.CardId;

            _context.Remove(earliestHold);
            _context.SaveChanges();
            RentItem(bookId, cardId);
        }

        private void RemoveExistingRent(int id)
        {
            var rent = _context.Rents
                .Include(r => r.Textbook)
                .FirstOrDefault(r => r.Textbook.Id == id);

            _context.Remove(rent);
        }

        private void CloseExistingRentHistory(int id, DateTime now, int renterId)
        {
            var history = _context.RentHistories
                .FirstOrDefault(rh => rh.Textbook.Id == id && rh.Renter.Id == renterId && rh.Returned.ToString() == "0001-01-01 00:00:00.0000000");

            _context.Update(history);
            history.Returned = now;
        }

        private void UpdateTXStatus(int txId, string v)
        {
            var book = _context.Textbooks
                .Include(tx => tx.Status)
                .FirstOrDefault(tx => tx.Id == txId);

            _context.Update(book);
            book.Status = _context.Statuses.FirstOrDefault(s => s.Name == v);
        }

        public IEnumerable<Renter> GetCurrentRenters(int id)
        {
            var rents = _context.Rents
                .Include(r => r.Textbook)
                .Include(r => r.RentCard)
                .Where(r => r.Textbook.Id == id);

            IEnumerable<Renter> renters = Enumerable.Empty<Renter>();

            foreach(Rent r in rents)
            {
                var renter = _context.Renters
                    .Include(renter => renter.RentCard)
                    .FirstOrDefault(renter => renter.RentCard.Id == r.RentCard.Id);
                renters.Append(renter);
            }

            return renters;
        }
    }
}
