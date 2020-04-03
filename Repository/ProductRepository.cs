using ProductMicroservice.DBContext;
using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            this._context = context;
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            _context.Products.Remove(product);
            Save();
        }

        public Product GetProductByID(int productId)
        {
            return _context.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _context.Add(product);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            //There are 3 ways of updating, 
            // Entry() method in case you want to update all the fields in your object.

            //1. 
            //  _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //  Save();

            //2.
            //  var oldProd = _context.Products.Find(product.Id);
            //  _context.Entry(oldProd).CurrentValues.SetValues(product);
            //  Save();

            //3.
            var dbProdEntry = _context.Entry(product);
            foreach(var property in dbProdEntry.OriginalValues.Properties)
            {
                var original = dbProdEntry.OriginalValues.GetValue<object>(property);
                var current = dbProdEntry.CurrentValues.GetValue<object>(property);
                if(original != null && !original.Equals(current))
                    dbProdEntry.Property(property.Name).IsModified = true;
            }
            Save();
        }
    }
}
