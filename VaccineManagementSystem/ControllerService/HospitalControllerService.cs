using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaccineManagementSystem.Proxy;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.ControllerService
{
    
    public class HospitalControllerService : IHospitalControllerService
    {
        private readonly IHospitalProxy proxy;
        private readonly ICustomerProxy customerproxy;
        private readonly IVaccineTypeProxy vaccineProxy;
        public HospitalControllerService(IVaccineTypeProxy vaccineProxy, IHospitalProxy proxy, ICustomerProxy customerproxy)
        {
            this.vaccineProxy = vaccineProxy;
            this.proxy = proxy;
            this.customerproxy = customerproxy;
        }
        public void PostHospital(Hospital hospital)
        {
            Models.Hospital hospitalModel = AutoMapper.Mapper.Map<ViewModel.Hospital, Models.Hospital>(hospital);
            proxy.PostHospital(hospitalModel);
        }
        public List<Hospital> GetHospitals()
        {
            var vaccineTypes = proxy.GetAllHospitals();
            List<ViewModel.Hospital> vaccineTypeView = new List<Hospital>();
            foreach (var vaccineType in vaccineTypes)
            {
                vaccineTypeView.Add(AutoMapper.Mapper.Map<Models.Hospital, ViewModel.Hospital>(vaccineType));
            }
            return vaccineTypeView;
        }
        public void Vaccinated(int id,int status)
        {
            customerproxy.UpdateStatus(id, status);
        }
        public List<Hospital> GetAvailHospitals()
        {
            var vaccineTypes = proxy.GetAvailHospitals();
            List<ViewModel.Hospital> vaccineTypeView = new List<Hospital>();
            foreach (var vaccineType in vaccineTypes)
            {
                vaccineTypeView.Add(AutoMapper.Mapper.Map<Models.Hospital, ViewModel.Hospital>(vaccineType));
            }
            return vaccineTypeView;
        }
        public bool IsInDb(string email)
        {
            return proxy.IsInDb(email);
        }
        public List<Models.Customer> GetCustomersForHospital(string email)
        {
            List<Models.Customer> customers = new List<Models.Customer>();
            Models.Hospital hospital = new Models.Hospital();
            hospital = proxy.GetHospitalByEmail(email);
            if(hospital!=null)
            {
                customers = customerproxy.GetCustomersByHospitalId(hospital.Id);
            }
            
            return customers;
        }
        public List<CustomerOrdersViewModel> GetCustomerOrdersViewModel(string email)
        {
            List<CustomerOrdersViewModel> customerOrdersViewModels = new List<CustomerOrdersViewModel>();
            List<Models.Customer> customers = new List<Models.Customer>();
            List<Models.VaccineType> vaccineTypes = new List<Models.VaccineType>();
            Models.Hospital hospital = new Models.Hospital();
            hospital = proxy.GetHospitalByEmail(email);
            vaccineTypes = vaccineProxy.GetAllVaccineTypes();
            customers = customerproxy.GetCustomersByHospitalId(hospital.Id);
            if (customers != null)
            {
                foreach (var vaccineType in vaccineTypes)
                {
                    int countl = 0;
                    foreach (var cust in customers)
                    {
                        Models.Customer customer = new Models.Customer();
                        customer = cust;
                        if (customer.VaccineTypeId == vaccineType.Id)
                        {
                            countl = countl + 1;
                        }
                    }
                    CustomerOrdersViewModel customerOrdersViewModel = new CustomerOrdersViewModel()
                    {
                        VaccineName = vaccineType.Name,
                        count = countl
                    };
                    customerOrdersViewModels.Add(customerOrdersViewModel);
                }
            }

            return customerOrdersViewModels;
        }
    }
}