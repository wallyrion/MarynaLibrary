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
    public class ReaderRepository : IRepository<Reader>
    {
        private readonly Context _context;

        public ReaderRepository(Context context)
        {
            _context = context;
        }

        public List<Reader> GetAll()
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<Reader>("[dbo].[spGetAllReaders]", commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public int Create(Reader entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", entity.FirstName);
            parameters.Add("NewId", direction: ParameterDirection.Output, dbType:DbType.Int32);
            parameters.Add("LastName", entity.LastName);
            parameters.Add("Phone", entity.Phone);

            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                connection.Execute("[dbo].[spCreateReader]",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                var createdId = parameters.Get<int>("NewId");

                return createdId;
            }
        }

        public void Update(Reader entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id);
            parameters.Add("FirstName", entity.FirstName);
            parameters.Add("LastName", entity.LastName);
            parameters.Add("Phone", entity.Phone);

            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                connection.Execute("[dbo].[spUpdateReader]",
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
                connection.Execute("[dbo].[spDeleteReader]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}