using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Models;
using VaccineManagementSystemApi.Services;

namespace VaccineManagementSystem.Proxy
{
    public interface IManufacturerProxy
    {
        void PostManufacturer(Manufacturer manufacturer);
        List<Manufacturer> GetAllManufacturers();
        void EditManufacturer(Manufacturer manufacturer);
        void DeleteManufacturerById(int id);
        bool IsInDb(string email);
        Manufacturer GetManufacturerById(int id);
    }
}