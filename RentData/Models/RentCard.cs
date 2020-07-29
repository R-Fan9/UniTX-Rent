using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentData.Models
{
    public class RentCard
    {
        public int Id { get; set; }
        [Required]
        public string CardId { get; set; }
        [Column (TypeName ="decimal(18,2)")]
        public decimal LateFine { get; set; }
        public DateTime Created { get; set; }
        public virtual IEnumerable<Rent> Rented { get; set; }
    }
}
