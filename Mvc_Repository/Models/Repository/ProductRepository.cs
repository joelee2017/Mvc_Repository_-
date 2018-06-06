using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc_Repository.Models.Repository
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        public Products GetByID(int productID)
        {
            return this.Get(x => x.ProductID == productID);
        }

        public IEnumerable<Products> GetByCategory(int categoryID)
        {
            return this.GetAll().Where(x => x.CategoryID == categoryID);
        }       
    }
}