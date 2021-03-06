using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;

namespace VaccineManagementSystemApi.Services
{
    public interface IManufacturerQueryService
    {
        Manufacturer GetManufacturerById(int id);
        List<Manufacturer> GetAllManufacturers();
        bool IsInDb(string email);
        Manufacturer GetManufacturerByEmail(string email);
        List<Manufacturer> GetManufacturersByVaccineId(int id);
    }
}
