using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    [Table("ProductShippment")]
    public class ProductShippment : BaseEntity
    {
        public int OrderItemId { get; set; }
        [ForeignKey("OrderItemId")]
        public UserOrderItem UserOrderItem { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public DateTime ShipmentDateTime { get; set; }
    }
}
