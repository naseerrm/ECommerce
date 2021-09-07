using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int StockCount { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int ProductCategoryId { get; set; }

        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }

        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplierdetails Supplierdetails { get; set; }
        public int DiscountPercentage { get; set; }
    }
}
