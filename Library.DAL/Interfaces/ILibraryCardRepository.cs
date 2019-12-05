using System.Collections.Generic;
using Library.DAL.Models;

namespace Library.DAL.Interfaces
{
    public interface ILibraryCardRepository
    {
        List<LibraryCard> GetAll();

        int Create(LibraryCard card);
    }
}