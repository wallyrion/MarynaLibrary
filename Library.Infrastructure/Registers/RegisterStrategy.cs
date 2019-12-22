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

        static RegisterStrategy()
        {
            _registers = new Dictionary<DbType, Lazy<IRegister>>
            {
                {DbType.MongoDb, new Lazy<IRegister>(() => new MongoRegister())},
                {DbType.Sql, new Lazy<IRegister>(() => new SqlRegister())}
            };
        }

        public static void Register(Settings settings, IServiceCollection services)
        {
            _registers[settings.DbType].Value.Register(services, settings);
        }
    }
}