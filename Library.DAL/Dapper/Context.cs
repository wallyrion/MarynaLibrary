namespace Library.DAL.Dapper
{
    public class Context
    {
        public string ConnectionString { get; }

        public Context(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}