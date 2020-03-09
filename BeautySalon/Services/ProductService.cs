using BeautySalon.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySalon.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET SINGLE PRODUCT
        public Product GetProduct(int productId)
        {
            Product obj = new Product();
            return _db.Products.Include(u => u.Category).FirstOrDefault(u => u.Id == productId);
        }

        // GET ALL PRODUCTS
        public List<Product> GetProducts()
        {
            return _db.Products.Include(u => u.Category).ToList();
        }

        // GET ALL PRODUCT LISTS
        public List<Category> GetCategoryList()
        {
            return _db.Categories.ToList();
        }

        // CREATE PRODUCT USING
        public bool CreateProduct(Product objProduct)
        {
            _db.Products.Add(objProduct);
            _db.SaveChanges();
            return true;
        }

        // UPDATE PRODUCT
        public bool UpdateProduct(Product objProduct)
        {
            // GET PRODUCT FROM DATABASE 
            var ExistingProduct = _db.Products.FirstOrDefault(u => u.Id == objProduct.Id);
            // CHECK IF PRODUCT EXIST OR NOT
            if (ExistingProduct != null)
            {
                // DON'T CHANGE OR MAKE EMPTY THE IMAGE IF NOT CHANGED
                if (objProduct.Image == null)
                {
                    objProduct.Image = ExistingProduct.Image;
                }

                // IF EXIST THEN UPDATE PRODUCT
                _db.Products.Update(objProduct);
                // SAVE CHANGES 
                _db.SaveChanges();
            }
            else
            {
                // IF NOT EXIST THEN RETURN FALSE
                return false;
            }

            // IF EXISTING PRODUCT IS TRUE, RETURN TRUE THEN UPDATE AND SAVE CHANGE
            return true;
        }

        // DELETE PRODUCT FROM DATABASE 
        public bool DeleteProduct(Product objProduct)
        {
            // DELETE PRODUCT FROM DATABASE
            var ExistingProduct = _db.Products.FirstOrDefault(u => u.Id == objProduct.Id);
            // CHECK IF PRODUCT EXIST OR NOT
            if (ExistingProduct != null)
            {
                // IF EXIST THEN DELETE PRODUCT 
                _db.Products.Remove(ExistingProduct);
                    // SAVE CHANGES 
                _db.SaveChanges();
            }
            else
            {
                // IF NOT EXIST THEN RETURN FALSE
                return false;
            }
            // IF EXISTING PRODUCT IS TRUE, RETURN TRUE THEN DELETE AND SAVE CHANGE
            return true;
        }

    }
}
