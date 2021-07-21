using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.Repository.Entity;

namespace VaccineManagementSystemApi.Repository
{
    public interface IHospitalRepository
    {
        Hospital GetHospitalById(int id);
        List<Hospital> GetAllHospitals();
        void PostHospital(Hospital hospital);
        void DeleteHospitalById(int id);
        void EditHospital(Hospital hospital);
        bool IsInDb(string email);
        List<Hospital> GetAvailHospitals();
        Hospital GetHospitalByEmail(string email);

    }
}
