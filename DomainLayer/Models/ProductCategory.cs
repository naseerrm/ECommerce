using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    [Table("ProductCategory")]
    public class ProductCategory : BaseEntity
    {
        public string ProductCategoryName { get; set; }
        public string Description { get; set; }
    }
}
