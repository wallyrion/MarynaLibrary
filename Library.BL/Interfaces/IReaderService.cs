using System.Collections.Generic;
using Library.BL.Models;

namespace Library.BL.Interfaces
{
    public interface IReaderService
    {
        List<Book> GetAll();

        void Remove(int id);

        int Create(Reader reader);
    }
}