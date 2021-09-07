using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    [Table("ProductImage")]
    public class ProductImage : BaseEntity
    {
        public string ProductImageLink { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public ProductViewType ProductLinkType { get; set; }
    }

    public enum ProductViewType
    {
        Image,
        Video,
        Vimoe,
        Youtube
    }
}
