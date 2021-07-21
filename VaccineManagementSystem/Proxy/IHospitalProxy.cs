using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Models;
using VaccineManagementSystemApi.Services;

namespace VaccineManagementSystem.Proxy
{
    public interface IHospitalProxy
    {
        void PostHospital(Hospital hospital);
        List<Hospital> GetAllHospitals();
        void EditHospital(Hospital hospital);
        void DeleteHospitalById(int id);
        bool IsInDb(string email);
        Hospital GetHospitalById(int id);
        List<Hospital> GetAvailHospitals();
    }
}