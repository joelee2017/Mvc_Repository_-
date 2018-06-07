using Mvc_Repository.Models;
using Mvc_Repository.Models.Interface;
using Mvc_Repository.Models.Repository;
using Mvc_Repository.Service.Interface;
using Mvc_Repository.Service.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Repository.Service
{
    public class ProductService : IProductService
    {
        private IRepository<Products> repository = new GenericRepository<Products>();

        public IResult Create(Products instance)
        {
            if(instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this.repository.Create(instance);
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Update(Products instance)
        {
            if(instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this.repository.Update(instance);
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Delete(int productID)
        {
            IResult result = new Result(false);

            if (!this.IsExists(productID)) 
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = this.GetByID(productID);
                this.repository.Delete(instance);
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        //判斷是否存在
        public bool IsExists(int productID)
        {
            return this.repository.GetAll().Any(x => x.ProductID == productID);
        }

        public Products GetByID(int productID)
        {
            return this.repository.Get(x => x.ProductID == productID);
        }

        public IEnumerable<Products> GeAll()
        {
            return this.repository.GetAll();
        }

        public IEnumerable<Products> GetByCategory(int categoryID)
        {
            return this.repository.GetAll().Where(x => x.CategoryID == categoryID);
        }
        
    }
}
