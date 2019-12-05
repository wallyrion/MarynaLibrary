using System.Collections.Generic;
using Library.BL.Models;

namespace Library.BL.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAll();

        void Remove();

        void Create(Book book);
    }
}