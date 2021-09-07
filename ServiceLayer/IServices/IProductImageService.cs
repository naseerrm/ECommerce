using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IProductImageService
    {
        IEnumerable<ProductImage> GetAllProductImageByProductId(int ProductId);
        ProductImage GetProductImageById(int Id);
        void InsertProductImage(ProductImage productImage);
        void UpdateProductImage(ProductImage productImage);
        void DeleteProductImage(int Id);
    }
}
