using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;

namespace VaccineManagementSystemApi.Services
{
    public interface IDistributorQueryService
    {
        Distributor GetDistributorById(int id);
        List<Distributor> GetAllDistributors();
        List<string> GetLocations();
    }
}
