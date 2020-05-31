using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL.Dapper
{
    public class SqlContext
    {
        public string ConnectionString { get; }


        public SqlContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
