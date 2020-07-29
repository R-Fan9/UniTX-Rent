using Microsoft.EntityFrameworkCore;
using RentData.Models;
using System;

namespace RentData
{
    public class RentContext : DbContext
    {
        public RentContext(DbContextOptions options) : base(options) { }

        public DbSet<Hold> Holds { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<RentCard> RentCards { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<RentHistory> RentHistories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Textbook> Textbooks { get; set; }

    }
}
