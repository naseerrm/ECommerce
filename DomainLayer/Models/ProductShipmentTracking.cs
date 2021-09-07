using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    [Table("ProductShipmentTracking")]
    public class ProductShipmentTracking : BaseEntity
    {
        public int ProductShippmentId { get; set; }
        [ForeignKey("ProductShippmentId")]
        public ProductShippment ProductShippment { get; set; }
        public string ShippmentCurrentLocation { get; set; }
        public DateTime ShippmentCurrentLocationDateTime { get; set; }
    }
}
