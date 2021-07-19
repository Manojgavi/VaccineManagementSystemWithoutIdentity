using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Proxy;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.ControllerService
{
    public class HospitalControllerService : IHospitalControllerService
    {
        private readonly IHospitalProxy proxy;
        public HospitalControllerService(IHospitalProxy proxy)
        {
            this.proxy = proxy;
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
    }
}