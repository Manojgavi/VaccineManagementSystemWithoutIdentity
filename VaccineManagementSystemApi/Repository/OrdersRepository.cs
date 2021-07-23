using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.Repository.Context;
using VaccineManagementSystemApi.Repository.Entity;

namespace VaccineManagementSystemApi.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly AppDbContext dbContext;
        public OrdersRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void PlaceHospitalOrder(HospitalOrders hospitalOrders)
        {
            dbContext.HospitalOrders.Add(hospitalOrders);
            dbContext.SaveChanges();
        }
        public List<HospitalOrders> GetHospitalOrdersForDistributor(int id)
        {
            List<HospitalOrders> hospitalOrders = new List<HospitalOrders>();
            hospitalOrders = dbContext.HospitalOrders.Where(m => m.DistributorId == id&&m.Status=="Ordered").ToList();
            return hospitalOrders;
        }

        public void PlaceDistributorOrder(DistributorOrders distributorOrders1)
        {
            dbContext.DistributorOrders.Add(distributorOrders1);
            dbContext.SaveChanges();
        }

        

        public List<DistributorOrders> GetOrdersForManufacturer(int id)
        {
            List<DistributorOrders> distributorOrders = new List<DistributorOrders>();
            distributorOrders=dbContext.DistributorOrders.Where(m => m.ManufacturerId == id&&m.Status== "Ordered").ToList();
            return distributorOrders;
        }

        public void UpdateDistributorOrderStatus(int id)
        {
           var item=dbContext.DistributorOrders.Find(id);
            item.Status = "Delivered";
            dbContext.SaveChanges();
        }
        //public void UpdateHospitalOrdersById(int id)
        //{

        //}
    }
}
