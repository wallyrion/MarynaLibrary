using System;
using System.Collections.Generic;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using MongoDB.Driver;

namespace Library.DAL.Mongo
{
    public class BaseMongoRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly IMongoCollection<TEntity> _collection;

        public BaseMongoRepository(Context context)
        {
            _collection = context.GetCollection<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return _collection.FindSync(_ => true).ToList();

        }

        public Guid Create(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            _collection.InsertOne(entity);
            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new System.NotImplementedException();
        }
    }
}