using System;
using System.Collections.Generic;
using System.Text;

namespace RentData.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public virtual Textbook Textbook { get; set; }
        public virtual RentCard RentCard { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }
    }
}
