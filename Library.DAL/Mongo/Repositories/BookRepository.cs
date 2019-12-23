using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Library.DAL.Interfaces;
using Library.DAL.Models;

namespace Library.DAL.Mongo.Repositories
{
    public class BookRepository : BaseMongoRepository<Book>, IBookRepository
    {
        public BookRepository(Context context) : base(context)
        {
        }

        public List<Book> SearchBooks(string value)
        {
            return null;
        }
    }
}