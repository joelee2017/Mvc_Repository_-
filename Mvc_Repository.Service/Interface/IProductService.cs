﻿using Mvc_Repository.Models;
using Mvc_Repository.Service.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Repository.Service.Interface
{
    public interface IProductService
    {
        IResult Create(Products instance);

        IResult Update(Products instance);

        IResult Delete(int productID);

        bool IsExists(int productID);

        Products GetByID(int productID);

        IEnumerable<Products> GeAll();

        IEnumerable<Products> GetByCategory(int categoryID);

    }
}
