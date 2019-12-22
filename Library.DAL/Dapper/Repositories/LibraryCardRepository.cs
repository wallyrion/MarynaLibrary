using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Library.DAL.Interfaces;
using Library.DAL.Dapper.Models;

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

        public int Create(LibraryCard card)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ReaderId", card.ReaderId);
            parameters.Add("NewId", direction: ParameterDirection.Output, dbType: DbType.Int32);
            parameters.Add("BookId", card.BookId);

            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                connection.Execute("[dbo].[spCreateLibraryCard]",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                var createdId = parameters.Get<int>("NewId");

                return createdId;
            }
        }

        public void Update(int id)
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