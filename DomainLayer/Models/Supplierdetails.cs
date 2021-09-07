using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    [Table("Supplierdetails")]
    public class Supplierdetails : BaseEntity
    {
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CurrrentAddress { get; set; }
        public string AlternateAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public ApplicationUser ApplicationUser { get; set; }
        public bool SupplierBlocked { get; set; }
    }
}
