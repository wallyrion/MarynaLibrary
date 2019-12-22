namespace Library.DAL.Dapper
{
    public class Context
    {
        public string ConnectionString { get; }

        public string DbName { get; set; }

        public Context(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}