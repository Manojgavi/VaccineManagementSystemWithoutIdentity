using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.Repository.Entity;

namespace VaccineManagementSystemApi.Repository
{
    public interface IDistributorRepository
    {
        Distributor GetDistributorById(int id);
        List<Distributor> GetAllDistributors();
        void PostDistributor(Distributor distributor);
        void DeleteDistributorById(int id);
        void EditDistributor(Distributor distributor);
        List<string> GetLocations();
        bool IsInDb(string email);
        List<Distributor> GetAvailDistributors();
    }
}
