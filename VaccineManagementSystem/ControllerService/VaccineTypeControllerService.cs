using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.ViewModel;
using VaccineManagementSystem.Proxy;

namespace VaccineManagementSystem.ControllerService
{
    public class VaccineTypeControllerService : IVaccineTypeControllerService
    {
        private readonly IVaccineTypeProxy proxy;
        public VaccineTypeControllerService(IVaccineTypeProxy proxy)
        {
            this.proxy = proxy;
        }
        public List<VaccineType> GetVaccineTypes()
        {
            var vaccineTypes= proxy.GetAllVaccineTypes();
            List<ViewModel.VaccineType> vaccineTypeView = new List<VaccineType>();
            foreach(var vaccineType in vaccineTypes)
            {
                vaccineTypeView.Add(AutoMapper.Mapper.Map<Models.VaccineType, ViewModel.VaccineType>(vaccineType)); 
            }
            return vaccineTypeView;
        }
        public void DeleteVaccineTypeById(int id)
        {
            proxy.DeleteVaccineTypeById(id);
        }
        public VaccineType GetVaccineTypeById(int id)
        {
            VaccineType vaccineTypeView = new VaccineType();
            Models.VaccineType vaccineType = new Models.VaccineType();
            vaccineType = proxy.GetVaccineTypeById(id);
            vaccineTypeView = AutoMapper.Mapper.Map<Models.VaccineType, VaccineType>(vaccineType);
            return vaccineTypeView;
        }

        public void PostVaccineType(VaccineType vaccineType)
        {
            Models.VaccineType vaccineTypeModel = AutoMapper.Mapper.Map<ViewModel.VaccineType, Models.VaccineType>(vaccineType);
            proxy.PostVaccineType(vaccineTypeModel);
        }
    }
}