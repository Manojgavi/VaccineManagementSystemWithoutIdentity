using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class OrdersQueryService : IOrdersQueryService
    {
        private readonly IOrdersRepository ordersRepository;
        public OrdersQueryService(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }
        public List<HospitalOrders> GetHospitalOrdersForDistributor(int id)
        {
            List<Repository.Entity.HospitalOrders> hospitalOrders = new List<Repository.Entity.HospitalOrders>();
            hospitalOrders = ordersRepository.GetHospitalOrdersForDistributor(id);
            List<HospitalOrders> hospitalOrders1 = new List<HospitalOrders>();
            foreach(var hospitalOrder in hospitalOrders)
            {
                HospitalOrders order = new HospitalOrders();
                order = AutoMapper.Mapper.Map<Repository.Entity.HospitalOrders, HospitalOrders>(hospitalOrder);
                hospitalOrders1.Add(order);
                
            }
            return hospitalOrders1;
        }

        public List<DistributorOrders> GetOrdersForManufacturer(int id)
        {
            List<Repository.Entity.DistributorOrders> distributorOrders = new List<Repository.Entity.DistributorOrders>();
            distributorOrders = ordersRepository.GetOrdersForManufacturer(id);
            List<DistributorOrders> distributorOrders1 = new List<DistributorOrders>();
            foreach (var distributorOrder in distributorOrders)
            {
                DistributorOrders order = new DistributorOrders();
                order = AutoMapper.Mapper.Map<Repository.Entity.DistributorOrders, DistributorOrders>(distributorOrder);
                distributorOrders1.Add(order);

            }
            return distributorOrders1;

        }
    }
}
