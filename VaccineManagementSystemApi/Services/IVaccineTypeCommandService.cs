using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;

namespace VaccineManagementSystemApi.Services
{
    public interface IVaccineTypeCommandService
    {
        void PostVaccineType(VaccineType vaccineType);
        void DeleteVaccineTypeById(int id);
        void EditVaccineType(VaccineType vaccineType);
    }
}
