﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Library.DAL.Interfaces;
using Library.DAL.Models;

namespace Library.DAL.Dapper.Repositories
{
    public class ReaderRepository : IReaderRepository
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

        public Guid Create(Reader entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", entity.FirstName);
            parameters.Add("NewId", direction: ParameterDirection.Output, dbType: DbType.Guid);
            parameters.Add("LastName", entity.LastName);
            parameters.Add("Phone", entity.Phone);

            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                connection.Execute("[dbo].[spCreateReader]",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                var createdId = parameters.Get<Guid>("NewId");

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

        public void Remove(Guid id)
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

        public List<Reader> Search(string value)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Value", value);

            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<Reader>("[dbo].[spSearchReader]", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}