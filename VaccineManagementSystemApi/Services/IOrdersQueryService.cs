using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VaccineManagementSystemApi.DTO;
using System.Threading.Tasks;

namespace VaccineManagementSystemApi.Services
{
    public interface IOrdersQueryService
    {
        List<HospitalOrders> GetHospitalOrdersForDistributor(int id);
        List<DistributorOrders> GetOrdersForManufacturer(int id);
    }
}
