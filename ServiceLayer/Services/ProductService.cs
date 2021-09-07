using DomainLayer.Models;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public void DeleteProduct(int Id)
        {
            var product = GetProductdetailsById(Id);
            if (product != null)
            {
                _repository.Delete(product);
                _repository.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAllProductDetails()
        {
            return _repository.GetAll();
        }

        public List<Product> GetProductByProductCategoryId(int ProductCategoryId)
        {
            return _repository.GetAll().Where(x => x.ProductCategoryId == ProductCategoryId).ToList();
        }

        public Product GetProductdetailsById(int Id)
        {
            return _repository.Get(Id);
        }

        public void InsertProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentException("Empty Records");
            }
            else
            {
                _repository.Insert(product);
                _repository.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentException("Empty Records");
            }
            else
            {
                _repository.Update(product);
                _repository.SaveChanges();
            }
        }
    }
}
