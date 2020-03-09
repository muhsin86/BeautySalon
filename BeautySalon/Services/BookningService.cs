using BeautySalon.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySalon.Services
{
    public class BookningService
    {
        private readonly ApplicationDbContext _db;
        public BookningService(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateBookning(Bookning bookning)
        {
            bookning.ProductId = bookning.Product.Id;
            bookning.Product = null;
            _db.Booknings.Add(bookning);
            _db.SaveChanges();
            return true;
        }
        public List<Bookning> GetBooknings()
        {
            return _db.Booknings.Include(u => u.Product).Include(u => u.Product.Category).ToList();
        }


        public bool ConfirmBookning(Bookning objBookning)
        {
            var ExistingBookning = _db.Booknings.FirstOrDefault(x => x.Id == objBookning.Id);
            if (ExistingBookning != null)
            {
                ExistingBookning.IsConfirmed = true;
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DeleteBookning(Bookning objBookning)
        {
            var ExistingBookning = _db.Booknings.FirstOrDefault(x => x.Id == objBookning.Id);
            if (ExistingBookning != null)
            {
                _db.Booknings.Remove(ExistingBookning);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
