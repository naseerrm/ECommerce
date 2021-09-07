using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Employee : BaseEntity
    {
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
    }
}
