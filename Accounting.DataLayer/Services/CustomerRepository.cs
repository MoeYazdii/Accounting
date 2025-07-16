using Accounting.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Accounting.DataLayer.Services
{

    //dependency injection
    public class CustomerRepository : ICustomerRepository
    {
        private Accounting_DBEntities _db;

        public CustomerRepository(Accounting_DBEntities context)
        {
            _db = context;
        }

        public bool DeleteCustomer(Customers customer)
        {
            try
            {
                _db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var customer = _db.Customers.Find(customerId);
                DeleteCustomer(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Customers> GetAllCustomers()
        {
            return _db.Customers.ToList();
        }

        public IEnumerable<Customers> GetCustomersByFilters(string parameter)
        {
            return _db.Customers.Where(c => c.FullName.Contains(parameter)
                || c.Email.Contains(parameter)
                || c.Mobile.Contains(parameter)).ToList();
        }

        public Customers GetCustomersById(int customersId)
        {
            return _db.Customers.Find(customersId);
        }

        public bool InsertCustomer(Customers customer)
        {
            try
            {
                _db.Customers.Add(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool UpdateCustomer(Customers customer)
        {
            try
            {
                _db.Entry(customer).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}