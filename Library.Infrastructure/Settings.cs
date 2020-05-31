using System;
using System.Collections.Generic;
using Library.Infrastructure.Enums;
using Microsoft.Extensions.Configuration;

namespace Library.Infrastructure
{
    public class Settings
    {
        private Dictionary<DbType, string> connections = new Dictionary<DbType, string>
        {
            {DbType.Sql, "SQLConnection"},
            {DbType.MongoDb, "MongoDbConnection"}
        };

        public Settings(IConfiguration configuration)
        {
            var type = configuration["DbType"];
            var dbType = Enum.Parse<DbType>(type);

            DbType = dbType;
            ConnectionStringMongo = configuration.GetConnectionString(connections[DbType.MongoDb]);
            ConnectionStringSql = configuration.GetConnectionString(connections[DbType.Sql]);
            DbName = configuration["DbName"];
        }

        public string ConnectionStringMongo { get; }

        public string ConnectionStringSql { get; }

        public string DbName { get; }

        public DbType DbType { get; }
    }
}