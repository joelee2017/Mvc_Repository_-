using Mvc_Repository.Models;
using Mvc_Repository.Service.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Repository.Service.Interface
{
    public interface ICategoryService
    {
        IResult Create(Categories instance);

        IResult Update(Categories instance);

        IResult Delete(int categoryID);

        bool IsExists(int categoryID);

        Categories GetByID(int categoryID);

        IEnumerable<Categories> GetAll();
    }
}
