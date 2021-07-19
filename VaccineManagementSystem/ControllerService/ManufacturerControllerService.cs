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
        public ManufacturerControllerService()
        {

        }
        public ManufacturerControllerService(IManufacturerProxy manufacturerProxy, IVaccineTypeControllerService vaccineTypeControllerService)
        {
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
    }
}