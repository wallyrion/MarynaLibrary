using System.Collections.Generic;
using Library.BL.Models;

namespace Library.BL.Interfaces
{
    public interface ILibraryService
    {
        int Create(LibraryCard cardModel);

        List<LibraryCard> GetAll();

        void ReturnCard(int id);
    }
}