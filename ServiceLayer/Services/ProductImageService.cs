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
    public class ProductImageService : IProductImageService
    {
        private IRepository<ProductImage> _repository;
        public ProductImageService(IRepository<ProductImage> repository)
        {
            _repository = repository;
        }
        public void DeleteProductImage(int Id)
        {
            var productImage= GetProductImageById(Id);
            if (productImage != null)
            {
                _repository.Delete(productImage);
                _repository.SaveChanges();
            }
        }

        public IEnumerable<ProductImage> GetAllProductImageByProductId(int ProductId)
        {
            return _repository.GetAll().Where(x => x.ProductId == ProductId).ToList();
        }

        public ProductImage GetProductImageById(int Id)
        {
            return _repository.Get(Id);
        }

        public void InsertProductImage(ProductImage productImage)
        {
            if (productImage == null)
            {
                throw new ArgumentException("Empty Records");
            }
            else
            {
                _repository.Insert(productImage);
                _repository.SaveChanges();
            }
        }

        public void UpdateProductImage(ProductImage productImage)
        {
            if (productImage == null)
            {
                throw new ArgumentException("Empty Records");
            }
            else
            {
                _repository.Update(productImage);
                _repository.SaveChanges();
            }
        }
    }
}
