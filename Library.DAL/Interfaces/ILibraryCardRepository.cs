using System;
using System.Collections.Generic;
using Library.DAL.Models;

namespace Library.DAL.Interfaces
{
    public interface ILibraryCardRepository: IRepository<LibraryCard>
    {
        void ReturnBook(Guid id);
    }
}