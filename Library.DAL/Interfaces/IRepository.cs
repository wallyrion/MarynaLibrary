using System;
using System.Collections.Generic;
using Library.DAL.Models;

namespace Library.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity: IEntity
    {
        List<TEntity> GetAll();

        Guid Create(TEntity entity);

        void Update(TEntity entity);

        void Remove(Guid id);
    }
}