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
    public class LibraryCardRepository : IRepository<LibraryCard>
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
            parameters.Add("NewId", direction: ParameterDirection.Output);
            parameters.Add("BookId", card.BookId);
            parameters.Add("ScheduleReturnDate", card.ScheduleReturnDate);
            parameters.Add("Quantity", card.Quantity);

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

        public void Update(LibraryCard entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}