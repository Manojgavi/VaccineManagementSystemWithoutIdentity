using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.ControllerService
{
    public interface ICustomerControllerService
    {
        Customer Create();
        void PostCustomer(Customer customer);

    }
}
