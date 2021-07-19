using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.Repository.Entity;

namespace VaccineManagementSystemApi.Repository
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int id);
        List<Customer> GetAllCustomers();
        void PostCustomer(Customer customer);
        void DeleteCustomerById(int id);
        void EditCustomer(Customer customer);
    }
}
