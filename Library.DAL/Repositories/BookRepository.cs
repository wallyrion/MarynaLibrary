using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Library.DAL.Dapper;
using Library.DAL.Interfaces;
using Library.DAL.Models;

namespace Library.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Context _context;

        public BookRepository(Context context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<Book>("[dbo].[spGetAllBooks]", commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public int Create(Book book)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Author", book.Author);
            parameters.Add("NewId", direction: ParameterDirection.Output);
            parameters.Add("Title", book.Title);
            parameters.Add("Quantity", book.Quantity);

            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                connection.Execute("[dbo].[spCreateBook]",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                var createdId = parameters.Get<int>("NewId");

                return createdId;
            }
        }

        public void Update(Book book)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Author", book.Author);
            parameters.Add("Title", book.Title);
            parameters.Add("Quantity", book.Quantity);

            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                connection.Execute("[dbo].[spUpdateBook]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Remove(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                connection.Execute("[dbo].[spDeleteBook]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}