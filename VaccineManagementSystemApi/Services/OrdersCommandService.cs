using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class OrdersCommandService : IOrdersCommandService
    {
        private readonly IOrdersRepository repository;
        public OrdersCommandService(IOrdersRepository repository)
        {
            this.repository = repository;
        }

        public void PlaceDistributorOrder(DistributorOrders distributorOrders)
        {
            Repository.Entity.DistributorOrders distributorOrders1 = new Repository.Entity.DistributorOrders();
            distributorOrders1 = AutoMapper.Mapper.Map<DistributorOrders, Repository.Entity.DistributorOrders>(distributorOrders);
            repository.PlaceDistributorOrder(distributorOrders1);
        }

        public void PlaceHospitalOrder(HospitalOrders hospitalOrders)
        {
            Repository.Entity.HospitalOrders hospitalOrders1 = new Repository.Entity.HospitalOrders();
            hospitalOrders1 = AutoMapper.Mapper.Map<HospitalOrders, Repository.Entity.HospitalOrders>(hospitalOrders);
            repository.PlaceHospitalOrder(hospitalOrders1);
        }

        public void UpdateDistributorOrderStatus(int id)
        {
            repository.UpdateDistributorOrderStatus(id);
        }
    }
}
