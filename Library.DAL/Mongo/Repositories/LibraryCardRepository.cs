using System;
using Library.DAL.Dapper;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.DAL.Mongo.Repositories
{
    public class LibraryCardRepository : BaseMongoRepository<LibraryCard>, ILibraryCardRepository
    {
        private readonly MongoContext _context;

        public LibraryCardRepository(MongoContext context) : base(context)
        {
            _context = context;
        }

        public override Guid Create(LibraryCard entity)
        {
            var book = _context.Database.GetCollection<Book>(typeof(Book).Name)
                .FindSync(new BsonDocument("_id", entity.BookId))
                .FirstOrDefault();
            var reader = _context.Database.GetCollection<Reader>(typeof(Reader).Name)
                .FindSync(new BsonDocument("_id", entity.ReaderId))
                .FirstOrDefault();
            entity.Author = book.Author;
            entity.BookQuantity = book.Quantity;
            entity.Title = book.Title;
            entity.FirstName = reader.FirstName;
            entity.LastName = reader.LastName;
            entity.GivenDate = DateTime.Now;
            entity.Phone = reader.Phone;

            var res = base.Create(entity);

            return res;
        }

        public void ReturnBook(Guid id)
        {
            var libraryCard = Collection.FindSync(new BsonDocument("_id", id)).FirstOrDefault();
            libraryCard.ReturnDate = DateTime.UtcNow;

            Update(libraryCard);
        }
    }
}