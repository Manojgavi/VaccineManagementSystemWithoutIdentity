using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Models;
using VaccineManagementSystemApi.Services;

namespace VaccineManagementSystem.Proxy
{
    public interface ICustomerProxy
    {
        void PostCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        void EditCustomer(Customer customer);
        void DeleteCustomerById(int id);
        Customer GetCustomerById(int id);
    }
}