using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.DAL.Dapper;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.DAL.Mongo
{
    public class BaseMongoRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        protected readonly IMongoCollection<TEntity> Collection;

        public BaseMongoRepository(MongoContext context)
        {
            Collection = context.GetCollection<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return Collection.FindSync(_ => true).ToList();

        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var a = await Collection.FindAsync(_ => true);
            var res = a.ToList();
            return res;
        }

        public Task<Guid> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
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