using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Proxy;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.ControllerService
{
    public class ManufacturerControllerService : IManufacturerControllerService
    {
        private readonly IManufacturerProxy manufacturerProxy;
        private readonly IVaccineTypeControllerService vaccineTypeControllerService;
        private readonly IOrdersProxy ordersProxy;
        private readonly IDistributorProxy distributorProxy;
        public ManufacturerControllerService()
        {

        }
        public ManufacturerControllerService(IDistributorProxy distributorProxy,IOrdersProxy ordersProxy,IManufacturerProxy manufacturerProxy, IVaccineTypeControllerService vaccineTypeControllerService)
        {
            this.distributorProxy = distributorProxy;
            this.ordersProxy = ordersProxy;
            this.manufacturerProxy = manufacturerProxy;
            this.vaccineTypeControllerService = vaccineTypeControllerService;
        }
        public void PostManufacturer(Manufacturer manufacturer)
        {
            Models.Manufacturer manufacturerModel = AutoMapper.Mapper.Map<ViewModel.Manufacturer, Models.Manufacturer>(manufacturer);
            manufacturerProxy.PostManufacturer(manufacturerModel);
        }
        public Manufacturer Create()
        {
            Manufacturer manufacturer = new Manufacturer()
            {
                VaccineType = vaccineTypeControllerService.GetVaccineTypes()
            };
        return manufacturer;
        }
        public bool IsInDb(string email)
        {
            return manufacturerProxy.IsInDb(email);
        }
        public List<ManufacturerOrdersViewModel> GetManufacturerOrders(string email)
        {
            List<ManufacturerOrdersViewModel> viewModels = new List<ManufacturerOrdersViewModel>();
            Models.Manufacturer manufacturer = manufacturerProxy.GetManufacturerByEmail(email);
            List<Models.DistributorOrders> distributorOrders = new List<Models.DistributorOrders>();
            distributorOrders = ordersProxy.GetOrdersForManufacturer(manufacturer.Id);
            List<Models.Distributor> distributors = new List<Models.Distributor>();
            distributors = distributorProxy.GetAvailDistributors();
            var result = (from order in distributorOrders
                         join distributor in distributors
                         on order.DistributorId equals distributor.Id
                         select new
                         {
                             DistributorId = distributor.Id,
                             DistributorName = distributor.Name,
                             Id = order.Id,
                             Count = order.Orders
                         });
            foreach(var a in result)
            {
                ManufacturerOrdersViewModel vm = new ManufacturerOrdersViewModel()
                {
                    Id = a.Id,
                    DistributorName = a.DistributorName,
                    Count = a.Count,

                };
                viewModels.Add(vm);
            }
            return viewModels;
        }

        public void UpdateDistributorOrderStatus(int id)
        {
            ordersProxy.UpdateDistributorOrderStatus(id);
        }
    }
}