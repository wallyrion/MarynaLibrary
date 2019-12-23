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
    public class LibraryCardRepository : ILibraryCardRepository
    {
        private readonly Context _context;

        public LibraryCardRepository(Context context)
        {
            _context = context;
        }

        public List<LibraryCard> GetAll()
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<LibraryCard>("[dbo].[spGetLibraryCard]", commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public Guid Create(LibraryCard card)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ReaderId", card.ReaderId);
            parameters.Add("NewId", direction: ParameterDirection.Output, dbType: DbType.Guid);
            parameters.Add("BookId", card.BookId);

            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                connection.Execute("[dbo].[spCreateLibraryCard]",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                var createdId = parameters.Get<Guid>("NewId");

                return createdId;
            }
        }

        public void ReturnBook(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                connection.Execute("[dbo].[spReturnBook]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}