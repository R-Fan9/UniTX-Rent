using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentData.Models
{
    public class RentHistory
    {
        public int Id { get; set; }

        [Required]
        public virtual Textbook Textbook { get; set; }

        [Required]
        public virtual Renter Renter { get; set; }

        public DateTime RentedOut { get; set; }

        public DateTime Returned { get; set; }
    }
}
