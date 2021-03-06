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
        private readonly IOrdersProxy ordersProxy;
        private readonly IDistributorProxy distributorProxy;
        public HospitalControllerService(IDistributorProxy distributorProxy,IOrdersProxy ordersProxy, IVaccineTypeProxy vaccineProxy, IHospitalProxy proxy, ICustomerProxy customerproxy)
        {
            this.distributorProxy = distributorProxy;
            this.ordersProxy = ordersProxy;
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
        public List<CustomersDataViewModel> GetCustomersForHospital(string email)
        {
            List<Models.Customer> customers = new List<Models.Customer>();
            Models.Hospital hospital = new Models.Hospital();
            hospital = proxy.GetHospitalByEmail(email);
            if(hospital!=null)
            {
                customers = customerproxy.GetCustomersByHospitalId(hospital.Id);
            }
            List<Models.VaccineType> vaccineTypes = new List<Models.VaccineType>();
            vaccineTypes = vaccineProxy.GetAllVaccineTypes();
            List<CustomersDataViewModel> customersDataViews = new List<CustomersDataViewModel>();
            var result = (from customer in customers
                          join vaccine in vaccineTypes
                          on customer.VaccineTypeId equals vaccine.Id
                          select new
                          {
                              Id = customer.Id,
                              Name = customer.Name,
                              Gender = customer.Gender,
                              Email = customer.Email,
                              phoneNumber = customer.PhoneNumber,
                              Aadhar = customer.AadharNumber,
                              VaccineId = customer.VaccineTypeId,
                              VaccineName = vaccine.Name
                          });
            List<CustomersDataViewModel> customersDatas = new List<CustomersDataViewModel>();
            foreach(var customer in result)
            {
                CustomersDataViewModel customersData = new CustomersDataViewModel()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Gender = customer.Gender,
                    Email = customer.Email,
                    PhoneNumber = customer.phoneNumber,
                    AadharNumber = customer.Aadhar,
                    VaccineTypeId = customer.VaccineId,
                    VaccineName = customer.VaccineName

                };
                customersDatas.Add(customersData);
            }

            
            return customersDatas;
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
        public HospitalOrdersViewModel HospitalOrder()
        {
            
            HospitalOrdersViewModel hospitalOrdersViewModel = new HospitalOrdersViewModel()
            {
                VaccineTypes=vaccineProxy.GetAllVaccineTypes(),
                Distributors = distributorProxy.GetAvailDistributors()
            };
            return hospitalOrdersViewModel;
        }
        public void PostHospitalOrders(HospitalOrdersViewModel hospitalOrdersViewModel,string email)
        {
            Models.Hospital hospital = new Models.Hospital();
            hospital = proxy.GetHospitalByEmail(email);
            Models.HospitalOrders orders = new Models.HospitalOrders()
            {
                HospitalId = hospital.Id,
                Orders = hospitalOrdersViewModel.Order,
                VaccineTypeId = hospitalOrdersViewModel.VaccineTypeId,
                DistributorId = hospitalOrdersViewModel.DistributorId,
                Status="Ordered"
            };
            ordersProxy.PlaceHospitalOrder(orders);
        }
    }
}