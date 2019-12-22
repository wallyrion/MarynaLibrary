using System;
using System.Collections.Generic;
using Library.Infrastructure.Enums;
using Library.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure.Registers
{
    public class RegisterStrategy
    {
        private static Dictionary<DbType, Lazy<IRegister>> _registers;

        public RegisterStrategy()
        {
            _registers = new Dictionary<DbType, Lazy<IRegister>>
            {
                {DbType.MongoDb, new Lazy<IRegister>(() => new MongoRegister())},
                {DbType.Sql, new Lazy<IRegister>(() => new SqlRegister())}
            };
        }

        public static void Register(DbType type, IServiceCollection services)
        {
            _registers[type].Value.Register(services);
        }
    }
}