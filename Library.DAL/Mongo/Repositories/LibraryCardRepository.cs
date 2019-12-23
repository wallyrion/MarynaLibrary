using System;
using Library.DAL.Interfaces;
using Library.DAL.Models;

namespace Library.DAL.Mongo.Repositories
{
    public class LibraryCardRepository : BaseMongoRepository<LibraryCard>, ILibraryCardRepository
    {
        public LibraryCardRepository(Context context) : base(context)
        {
        }

        public void ReturnBook(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}