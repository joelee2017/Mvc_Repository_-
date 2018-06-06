using System;
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

namespace Mvc_Repository.Web.Controllers
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
        public ActionResult Index(string category = "all")
        {
            int categoryID = 1;

            ViewBag.CategorySelectList = int.TryParse(category, out categoryID)
                ? this.CategorySelectList(categoryID.ToString())
                : this.CategorySelectList("all");

            var result = category.Equals("all", StringComparison.OrdinalIgnoreCase)
                ? this.productRepository.GetAll()
                : productRepository.GetByCategory(categoryID);



            var products = productRepository.GetAll().OrderByDescending(x => x.ProductID).ToList();
            return View(products);
        }

        [HttpPost]
        public ActionResult ProductsOfCategory(string category)
        {
            return RedirectToAction("Index", new { category = category });
        }

        public List<SelectListItem> CategorySelectList(string selectedValue = "all")
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() {
                Text = "All Category",
                Value = "all",
                Selected = selectedValue.Equals("all", StringComparison.OrdinalIgnoreCase)
            });

            var categories = categoryRepository.GetAll().OrderBy(x => x.CategoryID);

            foreach(var c in categories)
            {
                items.Add(new SelectListItem() {
                    Text = c.CategoryName,
                    Value = c.CategoryID.ToString(),
                    Selected = selectedValue.Equals(c.CategoryID.ToString())
                });
            }
            return items;
        }

        //===========================================================================

        // GET: Product/Details/5
        public ActionResult Details(int? id, string category)
        {
            if (!id.HasValue) return RedirectToAction("index");

            Products products = productRepository.GetByID(id.Value);
            if (products == null)
            {
                return HttpNotFound();
            }

            ViewBag.Category = string.IsNullOrWhiteSpace(category) ? "all" : category;

            return View(products);
        }
        //===========================================================================

        // GET: Product/Create
        public ActionResult Create(string category)
        {
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName");
            ViewBag.Category = string.IsNullOrWhiteSpace(category) ? "all" : category;
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Products products, string category)
        {
            if (ModelState.IsValid)
            {
                this.productRepository.Create(products);
                return RedirectToAction("Index", new { category = category });
            }

            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }
        //========================================================================================

        // GET: Product/Edit/5
        public ActionResult Edit(int? id, string category)
        {
            if (!id.HasValue) return RedirectToAction("index");

            Products products = this.productRepository.GetByID(id.Value);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", products.CategoryID);
            ViewBag.Category = string.IsNullOrWhiteSpace(category) ? "all" : category;

            return View(products);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Products products, string category)
        {
            if (ModelState.IsValid)
            {
                this.productRepository.Update(products);
                return RedirectToAction("Index", new { category = category });
            }
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }
        //===================================================================================

        // GET: Product/Delete/5
        public ActionResult Delete(int? id, string category)
        {
            if (!id.HasValue) return RedirectToAction("index");

            Products products = this.productRepository.GetByID(id.Value);
            if (products == null)
            {
                return HttpNotFound();
            }

            ViewBag.Category = string.IsNullOrWhiteSpace(category) ? "all" : category;

            return View(products);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, string category)
        {
            Products products = this.productRepository.GetByID(id);
            this.productRepository.Delete(products);

            return RedirectToAction("Index", new { category = category });
        }
    }
}
