using MongoDB.Driver;

namespace Library.DAL.Mongo
{
    public class Context
    {
        public Context(string connectionString, string dbName)
        {
            MongoClient client = new MongoClient(connectionString);
            Database = client.GetDatabase(dbName);
            ConnectionString = connectionString;
            DbName = dbName;
        }

        public string DbName { get; }

        public string ConnectionString { get; }

        public IMongoDatabase Database { get; }

        public IMongoCollection<TCollection> GetCollection<TCollection>() where TCollection : class
        {
            return Database.GetCollection<TCollection>(typeof(TCollection).Name);
        }
    }
}