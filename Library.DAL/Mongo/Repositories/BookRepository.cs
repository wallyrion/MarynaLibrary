using System.Collections.Generic;
using System.Linq;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using MongoDB.Driver;

namespace Library.DAL.Mongo.Repositories
{
    public class BookRepository : BaseMongoRepository<Book>, IBookRepository
    {
        private readonly Context _context;

        public BookRepository(Context context) : base(context)
        {
            _context = context;
        }

        public List<Book> SearchBooks(string value)
        {
            var cards = _context.Database.GetCollection<LibraryCard>(typeof(LibraryCard).Name).AsQueryable();
            var books = _collection
                .AsQueryable()
                .Where(b =>
                    b.Author.Contains(value)
                    || b.Title.Contains(value))
                .ToList();
            var selected = new List<Book>();

            foreach (var b in books)
            {
                var count = cards.Where(c => b.Id == c.BookId && c.ReturnDate == null).ToList().Count;
                b.AvailableCount = b.Quantity - count;

                if (b.AvailableCount > 0)
                {
                    selected.Add(b);
                }
            }

            return selected;
        }
    }
}