using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc_Repository.Models.Repository
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        protected TestDBEntities db
        {
            get;
            private set;
        }

        public ProductRepository()
        {
            this.db = new TestDBEntities();
        }

        public void Create(Products instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Products.Add(instance);
                this.SaveChanges();
            }
        }

        public void Update(Products instance)
        {
            if(instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Modified;
                this.SaveChanges();
            }
        }

        public void Delete(Products instance)
        {
            if(instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Modified;
                this.SaveChanges();
            }
        }
            

        public Products Get(int productID)
        {
            return db.Products.FirstOrDefault(x => x.ProductID == productID);
        }

        public IQueryable<Products> GetAll()
        {
            return db.Products.Include(p => p.Categories).OrderByDescending(x => x.ProductID);
        }

        public void SaveChanges()
        {
            this.db.SaveChanges();
        }
              

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}