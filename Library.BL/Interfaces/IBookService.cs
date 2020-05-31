using System;
using System.Collections.Generic;
using Library.BL.Models;

namespace Library.BL.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAll();

        void Remove(Guid id);

        Guid Create(Book book);

        void Edit(Book book);

        List<Book> Search(string value);
    }
}