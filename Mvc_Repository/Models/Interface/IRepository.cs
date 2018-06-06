using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Repository.Models.Interface
{
    public interface IRepository<TEntity> :IDisposable
        where TEntity :class
    {
        void Create(TEntity instance);

        void Update(TEntity instance);

        void Delete(TEntity instance);

        TEntity Get(int PrimaryID);

        IQueryable<TEntity> GetAll();

        void SaveChanges();
    }
}