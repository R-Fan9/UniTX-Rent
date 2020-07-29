using System;
using System.Collections.Generic;
using System.Text;

namespace RentData.Models
{
    public class Hold
    {
        public int Id { get; set; }
        public virtual Textbook Textbook { get; set; }
        public virtual RentCard RentCard { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}
