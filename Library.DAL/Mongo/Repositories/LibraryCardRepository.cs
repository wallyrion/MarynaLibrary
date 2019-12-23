using System;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.DAL.Mongo.Repositories
{
    public class LibraryCardRepository : BaseMongoRepository<LibraryCard>, ILibraryCardRepository
    {
        public LibraryCardRepository(Context context) : base(context)
        {
        }

        public void ReturnBook(Guid id)
        {
            var libraryCard = _collection.FindSync(new BsonDocument("_id", id)).FirstOrDefault();
            libraryCard.ReturnDate = DateTime.UtcNow;

            Update(libraryCard);
        }
    }
}