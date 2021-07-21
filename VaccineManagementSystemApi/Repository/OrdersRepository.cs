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
    }
}
