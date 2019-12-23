using System;
using System.Collections.Generic;
using Library.BL.Models;

namespace Library.BL.Interfaces
{
    public interface IReaderService
    {
        List<Reader> GetAll();

        void Remove(Guid id);

        Guid Create(Reader reader);

        void Edit(Reader reader);

        List<Reader> Search(string value);
    }
}