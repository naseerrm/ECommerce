using DomainLayer.Models;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class SupplierService : ISupplierService
    {
        public IRepository<Supplierdetails> _repository;
        public SupplierService(IRepository<Supplierdetails> repository)
        {
            _repository = repository;
        }
        public void DeleteSupplier(int Id)
        {
            var supplier = GetSupplierdetailsById(Id);
            if (supplier != null)
            {
                _repository.Delete(supplier);
                _repository.SaveChanges();
            }
        }

        public IEnumerable<Supplierdetails> GetAllSupplierDetails()
        {
            return _repository.GetAll();
        }

        public Supplierdetails GetSupplierdetailsById(int Id)
        {
            return _repository.Get(Id);
        }

        public void InsertSupplier(Supplierdetails supplierdetails)
        {
            if (supplierdetails == null)
            {
                throw new ArgumentException("Empty Records");
            }
            else
            {
                _repository.Insert(supplierdetails);
                _repository.SaveChanges();
            }
        }

        public void UpdateSupplier(Supplierdetails supplierdetails)
        {
            if (supplierdetails == null)
            {
                throw new ArgumentException("Empty Records");
            }
            else
            {
                _repository.Update(supplierdetails);
                _repository.SaveChanges();
            }
        }
    }
}
