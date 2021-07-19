using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;

namespace VaccineManagementSystemApi.Services
{
    public interface IManufacturerCommandService
    {
        void PostManufacturer(Manufacturer manufacturer);
        void DeleteManufacturerById(int id);
        void EditManufacturer(Manufacturer manufacturer);
    }
}
