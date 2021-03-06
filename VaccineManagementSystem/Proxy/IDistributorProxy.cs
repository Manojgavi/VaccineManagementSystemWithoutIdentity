using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Models;
using VaccineManagementSystemApi.Services;

namespace VaccineManagementSystem.Proxy
{
    public interface IDistributorProxy
    {
        void PostDistributor(Distributor distributor);
        List<Distributor> GetAllDistributors();
        Distributor GetDistributorByEmail(string email);
        void EditDistributor(Distributor distributor);
        List<string> GetLocations();
        void DeleteDistributorById(int id);
        Distributor GetDistributorById(int id);
        bool IsInDb(string email);
        List<Distributor> GetAvailDistributors();
        void UpdateHospitalOrdersById(int id);
    }
}