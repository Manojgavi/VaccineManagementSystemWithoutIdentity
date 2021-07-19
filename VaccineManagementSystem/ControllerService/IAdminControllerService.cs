using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.ControllerService
{
    public interface IAdminControllerService
    {
        List<Manufacturer> GetManufacturers();
        List<Distributor> GetDistributors();
        List<Hospital> GetHospitals();
        RegisterViewModel UserFromHospital(int id);
        RegisterViewModel UserFromDistributor(int id);
        RegisterViewModel UserFromManufacturer(int id);
    }
}
