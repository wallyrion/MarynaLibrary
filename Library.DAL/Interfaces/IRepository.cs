using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.DAL.Models;

namespace Library.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity: IEntity
    {
        List<TEntity> GetAll();

        Task<List<TEntity>> GetAllAsync();

        Task<Guid> CreateAsync(TEntity entity);

        Guid Create(TEntity entity);

        void Update(TEntity entity);

        void Remove(Guid id);
    }
}