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
    public class CategoryService : ICategoryService
    {
        private IRepository<Categories> repository = new GenericRepository<Categories>();

        public IResult Create(Categories instance)
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

        public IResult Update(Categories instance)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int categoryID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categories> GetAll()
        {
            throw new NotImplementedException();
        }

        public Categories GetByID(int categoryID)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int categoryID)
        {
            throw new NotImplementedException();
        }

       
    }
}
