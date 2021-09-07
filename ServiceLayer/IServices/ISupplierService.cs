using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface ISupplierService
    {
        IEnumerable<Supplierdetails> GetAllSupplierDetails();
        Supplierdetails GetSupplierdetailsById(int Id);
        void InsertSupplier(Supplierdetails supplierdetails);
        void UpdateSupplier(Supplierdetails supplierdetails);
        void DeleteSupplier(int Id);
    }
}
