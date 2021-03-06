using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;

namespace VaccineManagementSystemApi.Services
{
    public interface IOrdersCommandService
    {
        void PlaceHospitalOrder(HospitalOrders hospitalOrders);
        void PlaceDistributorOrder(DistributorOrders distributorOrders1);
        void UpdateDistributorOrderStatus(int id);
    }
}
