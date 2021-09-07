using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetAllProductCategoryDetails();
        ProductCategory GetProductCategoryById(int Id);
        void InsertProductCategory(ProductCategory productCategory);
        void UpdateProductCategory(ProductCategory productCategory);
        void DeleteProduct(int Id);
    }
}
