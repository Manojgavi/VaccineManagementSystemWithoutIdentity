using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Models;
using VaccineManagementSystemApi.Services;
using VaccineManagementSystemApi;

namespace VaccineManagementSystem.Proxy
{
    public class OrdersProxy : IOrdersProxy
    {
        private readonly IOrdersCommandService ordersCommandService;
        private readonly IOrdersQueryService ordersQueryService;
        public OrdersProxy(IOrdersCommandService ordersCommandService, IOrdersQueryService ordersQueryService)
        {
            this.ordersCommandService = ordersCommandService;
            this.ordersQueryService = ordersQueryService;
        }

        public List<HospitalOrders> GetHospitalOrdersForDistributor(int id)
        {
            List<VaccineManagementSystemApi.DTO.HospitalOrders> hospitalOrders = new List<VaccineManagementSystemApi.DTO.HospitalOrders>();
            hospitalOrders = ordersQueryService.GetHospitalOrdersForDistributor(id);
            List<HospitalOrders> hospitalOrders1 = new List<HospitalOrders>();
            foreach(var hospitalOrder in hospitalOrders)
            {
                HospitalOrders orders = new HospitalOrders();
                orders = AutoMapper.Mapper.Map<VaccineManagementSystemApi.DTO.HospitalOrders, HospitalOrders>(hospitalOrder);
                hospitalOrders1.Add(orders);

            }
            return hospitalOrders1;
        }

        public List<DistributorOrders> GetOrdersForManufacturer(int id)
        {
            List<DistributorOrders> distributorOrders1 = new List<DistributorOrders>();
            List<VaccineManagementSystemApi.DTO.DistributorOrders> distributorOrders = new List<VaccineManagementSystemApi.DTO.DistributorOrders>();
            distributorOrders=ordersQueryService.GetOrdersForManufacturer(id);
            foreach(var order in distributorOrders)
            {
                DistributorOrders orders = new DistributorOrders();
                orders = AutoMapper.Mapper.Map<VaccineManagementSystemApi.DTO.DistributorOrders, DistributorOrders>(order);
                distributorOrders1.Add(orders);
            
            }
            return distributorOrders1;
        }

        public void PlaceDistributorOrder(DistributorOrders orders)
        {
            VaccineManagementSystemApi.DTO.DistributorOrders distributorOrders1 = new VaccineManagementSystemApi.DTO.DistributorOrders();
            distributorOrders1 = AutoMapper.Mapper.Map<DistributorOrders, VaccineManagementSystemApi.DTO.DistributorOrders>(orders);
            ordersCommandService.PlaceDistributorOrder(distributorOrders1);
        }

        public void PlaceHospitalOrder(HospitalOrders hospitalOrders)
        {
            VaccineManagementSystemApi.DTO.HospitalOrders hospitalOrders1 = new VaccineManagementSystemApi.DTO.HospitalOrders();
            hospitalOrders1 = AutoMapper.Mapper.Map<HospitalOrders, VaccineManagementSystemApi.DTO.HospitalOrders>(hospitalOrders);
            ordersCommandService.PlaceHospitalOrder(hospitalOrders1);
        }

        public void UpdateDistributorOrderStatus(int id)
        {
            ordersCommandService.UpdateDistributorOrderStatus(id);
        }
    }
}