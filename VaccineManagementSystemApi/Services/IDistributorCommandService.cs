using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;

namespace VaccineManagementSystemApi.Services
{
    public interface IDistributorCommandService
    {
        void PostDistributor(Distributor distributor);
        void DeleteDistributorById(int id);
        void EditDistributor(Distributor distributor);
    }
}
