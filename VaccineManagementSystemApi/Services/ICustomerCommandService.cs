using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;

namespace VaccineManagementSystemApi.Services
{
    public interface ICustomerCommandService
    {
        void PostCustomer(Customer customer);
        void DeleteCustomerById(int id);
        void EditCustomer(Customer customer);
        void UpdateStatus(int id, int status);
    }
}
