using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using MongoDB.Driver;

namespace Library.DAL.Mongo.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly IMongoCollection<Reader> _collection;
        public ReaderRepository(Context context)
        {
            _collection = context.GetCollection<Reader>();
        }

        public List<Reader> GetAll()
        {
            return _collection.FindSync(_ => true).ToList();
        }

        public int Create(Reader entity)
        {
            entity.Id = Guid.NewGuid();
            _collection.InsertOne(entity);
            return 1;
        }

        public void Update(Reader entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Reader> Search(string value)
        {
            throw new System.NotImplementedException();
        }
    }
}