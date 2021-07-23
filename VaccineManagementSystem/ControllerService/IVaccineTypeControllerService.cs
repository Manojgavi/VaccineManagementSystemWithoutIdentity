using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.ControllerService
{
    public interface IVaccineTypeControllerService
    {
        List<ViewModel.VaccineType> GetVaccineTypes();
        void PostVaccineType(VaccineType vaccineType);
        void DeleteVaccineTypeById(int id);
        VaccineType GetVaccineTypeById(int id);

    }
}