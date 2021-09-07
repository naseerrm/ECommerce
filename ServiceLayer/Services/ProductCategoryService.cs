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
    public class ProductCategoryService : IProductCategoryService
    {
        private IRepository<ProductCategory> _repository;
        public ProductCategoryService(IRepository<ProductCategory> repository)
        {
            _repository = repository;
        }
        public void DeleteProduct(int Id)
        {
            var productCategory = GetProductCategoryById(Id);
            if (productCategory != null)
            {
                _repository.Delete(productCategory);
                _repository.SaveChanges();
            }
        }

        public IEnumerable<ProductCategory> GetAllProductCategoryDetails()
        {
            return _repository.GetAll();
        }

        public ProductCategory GetProductCategoryById(int Id)
        {
            return _repository.Get(Id);
        }

        public void InsertProductCategory(ProductCategory productCategory)
        {
            if (productCategory == null)
            {
                throw new ArgumentException("Empty Records");
            }
            else
            {
                _repository.Insert(productCategory);
                _repository.SaveChanges();
            }
        }

        public void UpdateProductCategory(ProductCategory productCategory)
        {
            if (productCategory == null)
            {
                throw new ArgumentException("Empty Records");
            }
            else
            {
                _repository.Update(productCategory);
                _repository.SaveChanges();
            }
        }
    }
}
