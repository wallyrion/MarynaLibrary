using System;
using System.Collections.Generic;
using Library.Infrastructure.Enums;
using Microsoft.Extensions.Configuration;

namespace Library.Infrastructure
{
    public class Settings
    {
        private static Dictionary<DbType, string> Connections = new Dictionary<DbType, string>
        {
            { DbType.Sql, "SQLConnection" },
            { DbType.MongoDb, "MongoDbConnection" }
        };

        public Settings(IConfiguration configuration)
        {
            var type = configuration["DbType"];
            var dbType = Enum.Parse<DbType>(type);


            ConnectionString = configuration[""];
        }


        public string ConnectionString { get;}

        public string DbName { get; }

        public DbType DbType { get; }


    }
}
