using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Library.DAL.Interfaces;
using Library.DAL.Models;

namespace Library.DAL.Mongo.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Dapper.Context _context;

        public BookRepository(Dapper.Context context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return null;
        }

        public int Create(Book entity)
        {
            return 0;
        }

        public void Update(Book entity)
        {
            return;
        }

        public void Remove(int id)
        {
        }

        public List<Book> SearchBooks(string value)
        {
            return null;
        }
    }
}