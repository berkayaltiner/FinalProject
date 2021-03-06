using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //I am working on Entity Framework , I will not work in Memory anymore.
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product{ ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15 },
            new Product{ ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3 },
            new Product{ ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2 },
            new Product{ ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65 },
            new Product{ ProductId=5, CategoryId=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);// Add function of List type
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query

            //We generally use First(), FirstOrDefault or SingleOrDefault() for ID based searching.

            /*If Condition in the "SingleOrDefault" comes true,
            First,FirstOrDefault and SingleOrDefault methods find one element and only give it.
            Those methods work like foreach .*/

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            /*If we didn't use LİNQ , we would use this algorithm.
             
            foreach ( var p in _products)
            {
               if (product.ProductId == p.ProductId)
               {
                 productToDelete = p;
               }
            }

             */

            _products.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;//returns all Products as a List.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //Where function returns all elements corresponding in the condition by making new list.
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDeteailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Find the product in the list equal to the submitted product ID.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }

        List<ProductDetailDto> IProductDal.GetProductDeteailDtos()
        {
            throw new NotImplementedException();
        }
    }
}
