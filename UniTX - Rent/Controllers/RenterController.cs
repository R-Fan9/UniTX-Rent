using Microsoft.AspNetCore.Mvc;
using RentData;
using RentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using UniTX___Rent.Models.JoinModel;
using UniTX___Rent.Models.Renter;
using UniTX___Rent.Models.SignOnModel;

namespace UniTX___Rent.Controllers
{
    public class RenterController : Controller
    {
        private IRenter _renter;
        private IRentCard _rentcard;
        public RenterController(IRenter renter, IRentCard rentcard)
        {
            _renter = renter;
            _rentcard = rentcard;
        }

        public IActionResult Detail(string cardId)
        {
            var renter = _renter.Get(cardId);
            var rentHistory = _renter.GetRentHistory(renter.Id)
                .Select(rh => new RentHistoryModel
                {
                    TXTitle = _renter.GetTXTitle(rh.Id),
                    RentedOut = rh.RentedOut.ToString(),
                    Returned = rh.Returned.ToString(),
                    LateFine = _renter.GetLateFine(rh.Id)

                });
            var model = new RenterDetailModel
            {
                LastName = renter.LastName,
                FirstName = renter.FirstName,
                Address = renter.Address,
                OverdueFees = renter.RentCard.LateFine,
                Telephone = renter.Telephone,
                TXRented = _renter.GetRents(cardId),
                Holds = _renter.GetHolds(cardId),
                RentHistory = rentHistory
            };
            return View(model);
        }


        public IActionResult SignOn()
        {
            var model = new SignOnModel
            {
                CardId = ""
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult PlaceSignOn(string CardId)
        {
            return RedirectToAction("Detail", new { cardId = CardId });
        }

        public IActionResult Join()
        {
            var model = new JoinModel
            {
                FirstName = "",
                LastName = "",
                Email = "",
                Telephone = "",
                Address = "",
                CardID = "",
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult PlaceJoin(JoinModel newRenter)
        {
            if (!_rentcard.checkCardId(newRenter.CardID))
            {
                var renter = new Renter
                {
                    FirstName = newRenter.FirstName,
                    LastName = newRenter.LastName,
                    Email = newRenter.Email,
                    Address = newRenter.Address,
                    Telephone = newRenter.Telephone,
                };
                _renter.Add(renter);

                var rentcard = new RentCard
                {
                    CardId = newRenter.CardID
                };
                _rentcard.Add(rentcard);

                _renter.linkRC(renter, rentcard);

                return RedirectToAction("Detail", new { cardId = newRenter.CardID });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }

    }
}
