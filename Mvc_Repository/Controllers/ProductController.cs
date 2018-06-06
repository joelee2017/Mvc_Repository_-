﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_Repository.Models;
using Mvc_Repository.Models.Interface;
using Mvc_Repository.Models.Repository;

namespace Mvc_Repository.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;

        public IEnumerable<Categories> Categories
        {
            get
            {
                return categoryRepository.GetAll();
            }
        }

        public ProductController()
        {
            this.productRepository = new ProductRepository();
            this.categoryRepository = new CategoryRepository();
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = productRepository.GetAll()
                .OrderByDescending(x => x.ProductID)
                .ToList();
            return View(products);
        }
        //===========================================================================

        // GET: Product/Details/5
        public ActionResult Details(int id = 0)
        {

            Products products = productRepository.GetByID(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }
        //===========================================================================

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", products.CategoryID);
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Products products)
        {
            if (ModelState.IsValid)
            {
                this.productRepository.Create(products);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }
        //========================================================================================

        // GET: Product/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Products products = this.productRepository.GetByID(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Products products)
        {
            if (ModelState.IsValid)
            {
                this.productRepository.Update(products);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }
        //===================================================================================

        // GET: Product/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Products products = this.productRepository.GetByID(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = this.productRepository.GetByID(id);
            this.productRepository.Delete(products);
            return RedirectToAction("Index");
        }
    }
}
