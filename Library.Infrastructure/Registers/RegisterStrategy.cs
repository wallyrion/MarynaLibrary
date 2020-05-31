using System;
using System.Collections.Generic;
using Library.DAL.Backup;
using Library.DAL.Dapper;
using Library.Infrastructure.Enums;
using Library.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure.Registers
{
    public class RegisterStrategy
    {
        private static readonly Dictionary<DbType, Lazy<IRegister>> Registers;

        static RegisterStrategy()
        {
            Registers = new Dictionary<DbType, Lazy<IRegister>>
            {
                {DbType.MongoDb, new Lazy<IRegister>(() => new MongoRegister())},
                {DbType.Sql, new Lazy<IRegister>(() => new SqlRegister())}
            };
        }

        public static void Register(Settings settings, IServiceCollection services)
        {
            services.AddScoped(options => new MongoContext(settings.ConnectionString, settings.DbName));
            services.AddScoped(options => new SqlContext(settings.ConnectionString));
            services.AddScoped<MongoBackupRepository>();
            services.AddScoped<SqlBackupRepository>();

            Registers[settings.DbType].Value.Register(services, settings);
        }
    }
}