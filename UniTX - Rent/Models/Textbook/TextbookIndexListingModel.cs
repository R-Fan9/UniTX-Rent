using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniTX___Rent.Models.Textbook
{
    public class TextbookIndexListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public string ImageUrl { get; set; }
        public int NumberOfCopies { get; set; }

    }
}
