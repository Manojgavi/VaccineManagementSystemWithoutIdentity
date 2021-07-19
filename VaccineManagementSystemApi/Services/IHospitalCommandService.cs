using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;

namespace VaccineManagementSystemApi.Services
{
    public interface IHospitalCommandService
    {
        void PostHospital(Hospital hospital);
        void DeleteHospitalById(int id);
        void EditHospital(Hospital hospital);
    }
}
