using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Library.DAL.Interfaces;
using Library.DAL.Models;

namespace Library.DAL.Dapper.Repositories
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

        public Guid Create(Book entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Author", entity.Author);
            parameters.Add("Title", entity.Title);
            parameters.Add("Quantity", entity.Quantity, DbType.Int32);
            parameters.Add("NewId", direction: ParameterDirection.Output, dbType:DbType.Int32);

            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                connection.Execute("[dbo].[spCreateBook]",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                var createdId = parameters.Get<Guid>("NewId");

                return createdId;
            }
        }

        public void Update(Book entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id);
            parameters.Add("Author", entity.Author);
            parameters.Add("Title", entity.Title);
            parameters.Add("Quantity", entity.Quantity);

            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                connection.Execute("[dbo].[spUpdateBook]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Remove(Guid id)
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

        public List<Book> SearchBooks(string value)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Value", value);

            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<Book>("[dbo].[spSearchBook]", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}