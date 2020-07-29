using Microsoft.AspNetCore.Mvc;
using RentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniTX___Rent.Models.RRHModel;
using UniTX___Rent.Models.Textbook;

namespace UniTX___Rent.Controllers
{
    public class TextbookController : Controller
    {
        private ITextbook _books;
        private IRent _rents;
        public TextbookController(ITextbook books, IRent rents)
        {
            _books = books;
            _rents = rents;
        }
        public IActionResult Index()
        {
            var txModels = _books.GetALL();
            var ListingResult = txModels
                .Select(result => new TextbookIndexListingModel
                {
                    Id = result.Id,
                    Title = result.Title,
                    Cost = result.Cost,
                    ImageUrl = result.ImageUrl,
                    NumberOfCopies = result.NumberOfCopies
                });
            var model = new TextbookIndexModel()
            {
                Textbooks = ListingResult
            };

            return View(model);

        }

        public IActionResult Detail(int id)
        {
            var book = _books.GetById(id);
            var currentHolds = _rents.GetCurrentHolds(id)
                .Select(a => new BookHoldModle
                {
                    HoldPlaced = _rents.GetCurrentHoldPlaced(a.Id).ToString("d"),
                    RenterName = _rents.GetCurrentHoldRenterName(a.Id)
                });

            var currentRenters = _rents.GetCurrentRenters(id)
                .Select(r => new CurrentRentersModel
                {
                    RenterName = r.FirstName + " " + r.LastName
                }); 

            var model = new TextbookDetailModel
            {
                BookId = id,
                Title = book.Title,
                Cost = book.Cost,
                Status = book.Status.Name,
                ImageUrl = book.ImageUrl,
                NumberOfCopies = book.NumberOfCopies,
                NumberOfRentOuts = book.NumberOfRentOuts,
                CurrentHolds = currentHolds,
                CurrentRenters = currentRenters,
                RentHistory = _rents.GetRentHistory(id)
                
            };
            return View(model);
        }

        private object Model(int id)
        {
            var book = _books.GetById(id);

            var model = new RRHModel
            {
                bookId = id,
                ImageUrl = book.ImageUrl,
                Title = book.Title,
                CardId = ""
            };
            return model;
        }

        public IActionResult Rent(int id)
        {
            return View(Model(id));
        }

        public IActionResult Return(int id)
        {
            return View(Model(id));
        }

        public IActionResult Hold(int id)
        {
            return View(Model(id));
        }

        [HttpPost]
        public IActionResult PlaceRent(int bookId, string CardId)
        {
            _rents.RentItem(bookId, CardId);
            return RedirectToAction("Detail", new { id = bookId });
        }

        [HttpPost]
        public IActionResult PlaceHold(int bookId, string CardId)
        {
            _rents.PlaceHold(bookId, CardId);
            return RedirectToAction("Detail", new { id = bookId });
        }

        [HttpPost]
        public IActionResult PlaceReturn(int bookId, string CardId)
        {
            _rents.ReturnItme(bookId, CardId);
            return RedirectToAction("Detail", new { id = bookId });
        }
    }
}
