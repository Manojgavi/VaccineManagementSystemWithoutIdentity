using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.Repository.Entity;
using VaccineManagementSystemApi.Repository.Context;
using System.Data.Entity;

namespace VaccineManagementSystemApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext dbContext;
        public CustomerRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void DeleteCustomerById(int id)
        {
            Customer customer = dbContext.Customers.Find(id);
            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            var customers = dbContext.Customers.Where(m=>m.Status=="Registered").ToList();

            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            var customer = dbContext.Customers.SingleOrDefault(m => m.Id == id);

            return customer;
        }

        public void PostCustomer(Customer customer)
        {
            //try
            //{
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();
                //return true;
            //}
            //catch(Exception)
            //{
            //    return false;
            //}
            

        }
        public List<Customer> GetCustomersByHospitalId(int id)
        {
            var customers = dbContext.Customers.Where(m => m.Status == "Registered"&&m.HospitalId==id).ToList();

            return customers;
        }
        public void EditCustomer(Customer customer)
        {
            dbContext.Entry(customer).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void UpdateStatus(int id, int status)
        {
            Customer customer = new Customer();
            customer = dbContext.Customers.Find(id);
            if(status==1)
            {
                customer.Status = "Vaccinated";
            }
            else if(status==2)
            {
                customer.Status = "NotShownUp";
            }
            dbContext.SaveChanges();
            
        }
    }
}
