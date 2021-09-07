using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProductDetails();
        Product GetProductdetailsById(int Id);
        List<Product> GetProductByProductCategoryId(int ProductCategoryId);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int Id);
    }
}
