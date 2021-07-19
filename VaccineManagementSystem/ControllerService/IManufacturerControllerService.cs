using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.ControllerService
{
    public interface IManufacturerControllerService
    {
        void PostManufacturer(Manufacturer manufacturer );
        Manufacturer Create();
        bool IsInDb(string email);
    }
}