using System.Collections.Generic;
using Library.BL.Models;

namespace Library.BL.Interfaces
{
    public interface IReaderService
    {
        List<Reader> GetAll();

        void Remove(int id);

        int Create(Reader reader);

        void Edit(Reader reader);

        List<Reader> Search(string value);
    }
}