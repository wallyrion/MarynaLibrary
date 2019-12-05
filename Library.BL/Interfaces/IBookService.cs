using System.Collections.Generic;
using Library.BL.Models;

namespace Library.BL.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAll();

        void Remove(int id);

        int Create(Book book);

        void Edit(Book book);

        List<Book> Search(string value);
    }
}