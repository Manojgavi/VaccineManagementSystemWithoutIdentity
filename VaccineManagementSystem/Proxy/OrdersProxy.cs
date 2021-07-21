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
        public OrdersProxy(IOrdersCommandService ordersCommandService)
        {
            this.ordersCommandService = ordersCommandService;
        }
        public void PlaceHospitalOrder(HospitalOrders hospitalOrders)
        {
            VaccineManagementSystemApi.DTO.HospitalOrders hospitalOrders1 = new VaccineManagementSystemApi.DTO.HospitalOrders();
            hospitalOrders1 = AutoMapper.Mapper.Map<HospitalOrders, VaccineManagementSystemApi.DTO.HospitalOrders>(hospitalOrders);
            ordersCommandService.PlaceHospitalOrder(hospitalOrders1);
        }
    }
}