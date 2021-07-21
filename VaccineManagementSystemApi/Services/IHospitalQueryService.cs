using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;

namespace VaccineManagementSystemApi.Services
{
    public interface IHospitalQueryService
    {
        Hospital GetHospitalById(int id);
        List<Hospital> GetAllHospitals();
        bool IsInDb(string email);
        List<Hospital> GetAvailHospitals();
    }
}
