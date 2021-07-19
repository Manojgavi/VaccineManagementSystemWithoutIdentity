using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;

namespace VaccineManagementSystemApi.Services
{
    public interface ICustomerQueryService
    {
        Customer GetCustomerById(int id);
        List<Customer> GetAllCustomers();
    }
}
