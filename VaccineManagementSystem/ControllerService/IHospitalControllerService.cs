using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.ControllerService
{
    public interface IHospitalControllerService
    {
        void PostHospital(Hospital hospital);
        List<Hospital> GetHospitals();
        bool IsInDb(string email);
        List<Hospital> GetAvailHospitals();
    }
}