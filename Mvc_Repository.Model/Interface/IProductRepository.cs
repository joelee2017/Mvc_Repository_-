using Mvc_Repository.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Repository.Models.Repository
{
    public interface IProductRepository: IRepository<Products>
    {
        Products GetByID(int productID);

        IEnumerable<Products> GetByCategory(int categoryID);
    }
}