using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Models;
namespace VaccineManagementSystem.Proxy
{
    public interface IOrdersProxy
    {
        void PlaceHospitalOrder(HospitalOrders hospitalOrders);
        List<HospitalOrders> GetHospitalOrdersForDistributor(int id);
        void PlaceDistributorOrder(DistributorOrders orders);
        List<DistributorOrders> GetOrdersForManufacturer(int id);
        void UpdateDistributorOrderStatus(int id);
    }
}