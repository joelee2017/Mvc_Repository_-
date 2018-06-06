using Mvc_Repository.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Repository.Models.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public void Create(TEntity instance)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity instance)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity instance)
        {
            throw new NotImplementedException();
        }      

        public TEntity Get(int PrimaryID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }              

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}