using System;
using System.Collections.Generic;
using Library.BL.Models;

namespace Library.BL.Interfaces
{
    public interface ILibraryService
    {
        Guid Create(LibraryCard cardModel);

        List<LibraryCard> GetAll();

        void ReturnBook(Guid id);
    }
}