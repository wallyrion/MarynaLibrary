using System;
using System.Collections.Generic;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.DAL.Mongo
{
    public class BaseMongoRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly IMongoCollection<TEntity> Collection;

        public BaseMongoRepository(Context context)
        {
            Collection = context.GetCollection<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return Collection.FindSync(_ => true).ToList();

        }

        public virtual Guid Create(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            Collection.InsertOne(entity);
            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            Collection.ReplaceOne(new BsonDocument("_id", entity.Id), entity);
        }

        public void Remove(Guid id)
        {
            Collection.DeleteOne(new BsonDocument("_id", id));
        }
    }
}