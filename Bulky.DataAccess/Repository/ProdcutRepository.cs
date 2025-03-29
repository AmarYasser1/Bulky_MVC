using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class ProdcutRepository : Repository<Product>, IProdcutRepository
    {
        private readonly ApplicationDbContext _db;
        public ProdcutRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            var product = _db.Products.FirstOrDefault(s => s.Id == obj.Id);
            if (product is not null) 
            {
                product.Title = obj.Title;
                product.Description = obj.Description;
                product.ISBN = obj.ISBN;
                product.Author = obj.Author;
                product.ListPrice = obj.ListPrice;
                product.Price = obj.Price;
                product.Price50 = obj.Price50;
                product.Price100 = obj.Price100;
                product.CategoryId = obj.CategoryId;
                product.ProductImages = obj.ProductImages;
                //if (obj.ImageUrl is not null)
                //{
                //    product.ImageUrl = obj.ImageUrl;
                //}
            }
        }
    }
}
