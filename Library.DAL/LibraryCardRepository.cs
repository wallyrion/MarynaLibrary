using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Library.DAL.Dapper;
using Library.DAL.Models;

namespace Library.DAL
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
                var result = connection.Query<LibraryCard>("[dbo].[usp_app_RetrieveEDIMetaDataList]", commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public int Create(LibraryCard card)
        {

            var parameters = new DynamicParameters();
            parameters.Add("ReaderId", card.ReaderId);
            parameters.Add("CreatedId", direction: ParameterDirection.Output);

            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                connection.Execute("[dbo].[usp_app_RetrieveEDIMetaDataList]",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                var createdId = parameters.Get<int>("CreatedId");
                return createdId;
            }
        }
    }
}