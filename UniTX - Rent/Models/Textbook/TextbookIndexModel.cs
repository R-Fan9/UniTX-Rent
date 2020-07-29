using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniTX___Rent.Models.Textbook
{
    public class TextbookIndexModel
    {
        public IEnumerable<TextbookIndexListingModel> Textbooks { get; set; }
    }
}
