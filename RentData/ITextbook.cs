using RentData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentData
{
    public interface ITextbook
    {
        IEnumerable<Textbook> GetALL();
        Textbook GetById(int id);
        void Add(Textbook newTX);
    }
}
