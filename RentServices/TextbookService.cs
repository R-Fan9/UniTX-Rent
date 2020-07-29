using Microsoft.EntityFrameworkCore;
using RentData;
using RentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentServices
{
    public class TextbookService : ITextbook
    {
        private RentContext _context;
        public TextbookService(RentContext context)
        {
            _context = context;
        }
        public void Add(Textbook newTX)
        {
            _context.Add(newTX);
            _context.SaveChanges();
        }

        public IEnumerable<Textbook> GetALL()
        {
            return _context.Textbooks
                .Include(tx => tx.Status);
        }

        public Textbook GetById(int id)
        {
            return GetALL()
                .FirstOrDefault(tx => tx.Id == id);
        }

    }
}
