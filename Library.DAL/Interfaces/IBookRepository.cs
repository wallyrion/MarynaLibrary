using System.Collections.Generic;
using Library.DAL.Models;

namespace Library.DAL.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAll();

        int Create(Book book);

        void Update(Book book);

        void Remove(int id);
    }
}