using System.Collections.Generic;
using Library.DAL.Models;

namespace Library.DAL.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        List<Book> SearchBooks(string value);
    }
}