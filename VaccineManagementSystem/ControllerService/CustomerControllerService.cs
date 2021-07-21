using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Proxy;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.ControllerService
{
    public class CustomerControllerService:ICustomerControllerService
    {
        private readonly ICustomerProxy proxy;
        private readonly IHospitalControllerService hospitalControllerService;
        private readonly IVaccineTypeControllerService vaccineTypeControllerService;
        public CustomerControllerService(ICustomerProxy proxy, IVaccineTypeControllerService vaccineTypeControllerService, IHospitalControllerService hospitalControllerService)
        {
            this.proxy = proxy;
            this.vaccineTypeControllerService = vaccineTypeControllerService;
            this.hospitalControllerService = hospitalControllerService;
        }

        public Customer Create()
        {
            Customer customer = new Customer()
            {
                Hospital = hospitalControllerService.GetAvailHospitals(),
                VaccineType = vaccineTypeControllerService.GetVaccineTypes()
            };
            return customer;
        }

        public void PostCustomer(Customer customer)
        {
            Models.Customer customerModel = new Models.Customer();
            customerModel = AutoMapper.Mapper.Map<ViewModel.Customer, Models.Customer>(customer);
            proxy.PostCustomer(customerModel);
        }
        
    }
}