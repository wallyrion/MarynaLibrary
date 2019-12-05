using System.Collections.Generic;

namespace Library.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        List<TEntity> GetAll();

        int Create(TEntity entity);

        void Update(TEntity entity);

        void Remove(int id);
    }
}