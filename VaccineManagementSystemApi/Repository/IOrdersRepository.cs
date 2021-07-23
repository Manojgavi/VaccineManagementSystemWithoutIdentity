using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.Repository.Entity;

namespace VaccineManagementSystemApi.Repository
{
    public interface IOrdersRepository
    {
        void PlaceHospitalOrder(HospitalOrders hospitalOrders);
        List<HospitalOrders> GetHospitalOrdersForDistributor(int id);
        void PlaceDistributorOrder(DistributorOrders distributorOrders1);
        
        List<DistributorOrders> GetOrdersForManufacturer(int id);
        void UpdateDistributorOrderStatus(int id);
    }
}
