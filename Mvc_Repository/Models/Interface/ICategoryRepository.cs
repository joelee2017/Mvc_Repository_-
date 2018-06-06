using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Repository.Models.Repository
{
    public interface ICategoryRepository
    {
        void Create(Categories instance);

        void Update(Categories instance);

        void Delete(Categories instance);

        Categories Get(int categoryID);

        IQueryable<Categories> GetAll();

        void SaveChanges();
    }
}