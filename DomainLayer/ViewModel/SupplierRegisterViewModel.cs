using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel
{
    public class SupplierRegisterViewModel : RegisterModel
    {
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CurrrentAddress { get; set; }
        public string AlternateAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
    }
}
