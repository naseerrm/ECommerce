using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    [Table("UserOrderItem")]
    public class UserOrderItem : BaseEntity
    {
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public ApplicationUser ApplicationUser { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public float TotalQuantityPrice { get; set; }
        public float SingleQuantityPrice { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
