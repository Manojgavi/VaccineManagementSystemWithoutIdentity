using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaccineManagementSystem.Proxy;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.ControllerService
{
    public class DistributorControllerService : IDistributorControllerService
    {
        private readonly IDistributorProxy proxy;
        private readonly IOrdersProxy ordersProxy;
        private readonly IVaccineTypeProxy vaccineProxy;
        private readonly IHospitalProxy hospitalProxy;
        public DistributorControllerService(IHospitalProxy hospitalProxy,IOrdersProxy ordersProxy,IVaccineTypeProxy vaccineProxy,IDistributorProxy proxy)
        {
            this.hospitalProxy = hospitalProxy;
            this.ordersProxy = ordersProxy;
            this.vaccineProxy = vaccineProxy;
            this.proxy = proxy;
        }
        public Distributor Create()
        {
            Distributor distributor = new Distributor()
            {
                Locations = new SelectList(proxy.GetLocations())
            };
            return distributor;
        }

        public void PostDistributor(Distributor distributor)
        {
            Models.Distributor distributorModel = new Models.Distributor();
            distributorModel = AutoMapper.Mapper.Map<ViewModel.Distributor, Models.Distributor>(distributor);
            proxy.PostDistributor(distributorModel);
        }
        public bool IsInDb(string email)
        {
           return proxy.IsInDb(email);
        }
        public List<OrdersFromHospitalVM> HospitalOrders(string email)
        {
            Models.Distributor distributor = proxy.GetDistributorByEmail(email);
            List<Models.HospitalOrders> orders = new List<Models.HospitalOrders>();
            orders=ordersProxy.GetHospitalOrdersForDistributor(distributor.Id);
            //List<Models.Distributor> distributors = proxy.GetAvailDistributors();
            List<Models.VaccineType> vaccineTypes = vaccineProxy.GetAllVaccineTypes();
            List<OrdersFromHospitalVM> ordersFromHospital = new List<OrdersFromHospitalVM>();
            List<Models.Hospital> hospitals = new List<Models.Hospital>();
            hospitals = hospitalProxy.GetAvailHospitals();
            var a = (from order in orders
                     join hospital in hospitals
                     on order.HospitalId equals hospital.Id
                     join vaccine in vaccineTypes on
                     order.VaccineTypeId equals vaccine.Id
                     select new
                     {
                         Id=order.Id,
                         HospitalName = hospital.HospitalName,
                         VaccineName = vaccine.Name,
                         Orders = order.Orders,
                         HospitalId=hospital.Id,
                         VaccineId=vaccine.Id
                     });
            foreach(var item in a)
            {
                OrdersFromHospitalVM viewmodel = new OrdersFromHospitalVM()
                {
                    HospitalName = item.HospitalName,
                    VaccineName = item.VaccineName,
                    HospitalId = item.HospitalId,
                    VaccineTypeId = item.VaccineId,
                    Orders=item.Orders,
                    Id=item.Id
                };
                ordersFromHospital.Add(viewmodel);
            }
            return ordersFromHospital;
        }
        public List<CustomerOrdersViewModel> GetHospitalOrdersViewModel(string email)
        {
            List<CustomerOrdersViewModel> customerOrdersViewModels = new List<CustomerOrdersViewModel>();
            List<Models.Hospital> hospitals = new List<Models.Hospital>();
            List<Models.VaccineType> vaccineTypes = new List<Models.VaccineType>();
            Models.Distributor distributor = new Models.Distributor();
            distributor = proxy.GetDistributorByEmail(email);
            vaccineTypes = vaccineProxy.GetAllVaccineTypes();
            List<Models.HospitalOrders> hospitalOrders = new List<Models.HospitalOrders>();
            hospitalOrders = ordersProxy.GetHospitalOrdersForDistributor(distributor.Id);
            //var result=(from order in hospitalOrders
            //            join hospital in hospitals
            //            on order.HospitalId equals hospital.Id
            //            join vaccine in vaccineTypes
            //            on order.VaccineTypeId equals vaccine.Id
            //            group by order.VaccineTypeId
            //            select new { VaccineName=vaccine.Id,})
            var result = (from order in hospitalOrders
                          group order by order.VaccineTypeId into g
                          join vaccine in vaccineTypes
                          on g.Key equals vaccine.Id
                          select new { Id=g.Key,VaccineName = vaccine.Name, orders = g.Sum(x => x.Orders) });
            foreach(var a in result)
            {
                CustomerOrdersViewModel customer = new CustomerOrdersViewModel()
                {
                    Id=a.Id,
                    VaccineName = a.VaccineName,
                    count = a.orders
                };
                customerOrdersViewModels.Add(customer);
            }
            return customerOrdersViewModels;
        }

        public void UpdateHospitalOrdersById(int id)
        {
            proxy.UpdateHospitalOrdersById(id);
        }

        public void PostDistributorOrders(DistributorOrdersViewModel viewModel, string email)
        {
            Models.Distributor distributor = new Models.Distributor();
            distributor = proxy.GetDistributorByEmail(email);
            Models.DistributorOrders orders = new Models.DistributorOrders()
            {
                DistributorId = distributor.Id,
                Orders = viewModel.Count,
                ManufacturerId=viewModel.ManufacturerId,
                Status = "Ordered"
            };
            ordersProxy.PlaceDistributorOrder(orders);
        }
    }
}