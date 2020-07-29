using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentData.Models
{
    public class Textbook
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public virtual Status Status { get; set; }

        [Required, Column(TypeName ="decimal(18,2)")]
        public decimal Cost { get; set; }
        public string ImageUrl { get; set; }
        public int NumberOfRentOuts { get; set; }
        public int NumberOfCopies { get; set; }

    }
}
