using System.Collections.Generic;
using Library.BL.Interfaces;
using Library.BL.Models;

namespace Library.BL.Services
{
    public class BookService : IBookService
    {
        public List<Book> GetAll()
        {
            return new List<Book>
            {
                new Book {Author = "fewrw", Id = 52, Quantity = 31, Title = "wertew"},
                new Book {Author = "fewrw", Id = 52, Quantity = 31, Title = "wertew"},

            };
        }

        public void Remove()
        {
        }

        public int Create(Book book)
        {
            return 12;
            throw new System.NotImplementedException();
        }

        public void Edit(Book book)
        {
            return;
            throw new System.NotImplementedException();
        }
    }
}