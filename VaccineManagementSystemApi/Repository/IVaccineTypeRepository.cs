using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.Repository.Entity;

namespace VaccineManagementSystemApi.Repository
{
    public interface IVaccineTypeRepository
    {
        VaccineType GetVaccineTypeById(int id);
        List<VaccineType> GetAllVaccineTypes();
        void PostVaccineType(VaccineType vaccineType);
        void DeleteVaccineTypeById(int id);
        void EditVaccineType(VaccineType vaccineType);
    }
}
