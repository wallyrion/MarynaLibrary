using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
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

            var books = cards.Where(c => c.ReturnDate == null)
                .GroupJoin(
                _collection.AsQueryable(),
                c => c.BookId,
                b => b.Id,
                (c, cb) => new
                {
                    Book = cb.First(),
                    Count = cb.Count()
                })
                .Select(cb => cb)
                .ToList()
                .Where(cb =>
                    cb.Book.Author.Contains(value, StringComparison.InvariantCultureIgnoreCase)
                    || cb.Book.Title.Contains(value, StringComparison.InvariantCultureIgnoreCase))
                .Where(cb => cb.Count < cb.Book.Quantity)
                .Select(b => b.Book)
                .ToList();

            return books;
        }
    }
}