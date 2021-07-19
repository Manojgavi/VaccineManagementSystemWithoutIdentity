using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;

namespace VaccineManagementSystemApi.Services
{
    public interface IVaccineTypeQueryService
    {
        VaccineType GetVaccineTypeById(int id);
        List<VaccineType> GetAllVaccineTypes();
    }
}
