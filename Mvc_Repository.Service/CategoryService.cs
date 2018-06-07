﻿using Mvc_Repository.Models;
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

        public IResult Delete(int categoryID)
        {
            IResult result = new Result(false);

            if(!this.IsExists(categoryID))
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = this.GetByID(categoryID);
                this.repository.Delete(instance);
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public bool IsExists(int categoryID)
        {
            return this.repository.GetAll().Any(x => x.CategoryID == categoryID);
        }

        public Categories GetByID(int categoryID)
        {
            return this.repository.Get(x => x.CategoryID == categoryID);
        }

        public IEnumerable<Categories> GetAll()
        {
            return this.repository.GetAll();
        }

    }
}
