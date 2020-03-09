using BeautySalon.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySalon.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET SINGLE CATEGORY
        public Category GetCategory(int categoryId)
        {
            Category obj = new Category();
            return _db.Categories.FirstOrDefault(u => u.Id == categoryId);
        }

        // GET ALL CATEGORIES
        public List<Category> GetCategories()
        {

            return _db.Categories.ToList();
        }

        // CREATE CATEGORY USING
        public bool CreateCategory(Category objCategory)
        {
            _db.Categories.Add(objCategory);
            _db.SaveChanges();
            return true;
        }
        // UPDATE CATEGORY
        public bool UpdateCategory(Category objCategory)
        {
            // GET CATEGORY FROM DATABASE 
            var ExistingCategory = _db.Categories.FirstOrDefault(u => u.Id == objCategory.Id);
            // CHECK IF CATEGORY EXIST OR NOT
            if (ExistingCategory != null)
            {
                // IF EXIST THEN UPDATE CATEGORY 
                ExistingCategory.Name = objCategory.Name;
                // SAVE CHANGES 
                _db.SaveChanges();
            }
            else
            {
                // IF NOT EXIST THEN RETURN FALSE
                return false;
            }

            // IF EXISTING CATEGORY IS TRUE, RETURN TRUE THEN UPDATE AND SAVE CHANGE
            return true;
        }

        // DELETE CATEGORY FROM DATABASE 
        public bool DeleteCategory(Category objCategory)
        {
            // DELETE CATEGORY FROM DATABASE 
            var ExistingCategory = _db.Categories.FirstOrDefault(u => u.Id == objCategory.Id);
            // CHECK IF CATEGORY EXIST OR NOT
            if (ExistingCategory != null)
            {
                // IF EXIST THEN DELETE CATEGORY 
                _db.Categories.Remove(ExistingCategory);
                // SAVE CHANGES 
                _db.SaveChanges();
            }
            else
            {
                // IF NOT EXIST THEN RETURN FALSE
                return false;
            }
            // IF EXISTING CATEGORY IS TRUE, RETURN TRUE THEN DELETE AND SAVE CHANGE
            return true;
        }
    }
}
