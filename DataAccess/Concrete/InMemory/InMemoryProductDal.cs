using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //Entities.Concrete deki Product.cs List ile türetme
         List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{CategoryId=1,ProductId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{CategoryId=2,ProductId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{CategoryId=3,ProductId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{CategoryId=4,ProductId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{CategoryId=5,ProductId=2,ProductName="Mouse",UnitPrice=85,UnitsInStock=1}

            };
        }

        //Ekleme
        public void Add(Product product)
        {
            _products.Add(product);
        }

        //Sİlme İşlemi
        public void Delete(Product product)

        {
            //Linq ile listeleme foreach yerine
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        //Listeleme
        public List<Product> GetAll()
        {
            return _products;
        }
        //Kategoriye göre filtreleme Linq 
        public List<Product> GetAllByCategory(int categoryId) => _products.Where(p => p.CategoryId == categoryId).ToList();

        //Güncelleme
        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }
}
