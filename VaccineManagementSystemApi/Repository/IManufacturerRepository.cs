using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.Repository.Entity;

namespace VaccineManagementSystemApi.Repository
{
    public interface IManufacturerRepository
    {
        Manufacturer GetManufacturerById(int id);
        List<Manufacturer> GetAllManufacturers();
        void PostManufacturer(Manufacturer manufacturer);
        void DeleteManufacturerById(int id);
        void EditManufacturer(Manufacturer manufacturer);
        bool IsInDb(string email);
    }
}
