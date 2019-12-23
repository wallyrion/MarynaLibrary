using System;
using System.Collections.Generic;
using Library.DAL.Models;

namespace Library.DAL.Interfaces
{
    public interface ILibraryCardRepository
    {
        List<LibraryCard> GetAll();

        Guid Create(LibraryCard card);

        void ReturnBook(Guid id);
    }
}