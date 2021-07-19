using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Models;
using VaccineManagementSystemApi.Services;

namespace VaccineManagementSystem.Proxy
{
    public interface IVaccineTypeProxy
    {
        void PostVaccineType(VaccineType vaccineType);
        List<VaccineType> GetAllVaccineTypes();
        void EditVaccineType(VaccineType vaccineType);
        void DeleteVaccineTypeById(int id);
        VaccineType GetVaccineTypeById(int id);
    }
}