
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class CustomerQueryService : ICustomerQueryService
    {
        private readonly ICustomerRepository repository;
        public CustomerQueryService(ICustomerRepository repository)
        {
            this.repository = repository;
        }
        public List<Customer> GetAllCustomers()
        {
            List<Repository.Entity.Customer> customers = new List<Repository.Entity.Customer>();

            customers = repository.GetAllCustomers();
            List<Customer> customerDto = new List<Customer>();
            foreach (var customer in customers)
            {
                customerDto.Add(AutoMapper.Mapper.Map<Repository.Entity.Customer, Customer>(customer));
            }

            return customerDto;
        }

        public Customer GetCustomerById(int id)
        {
            Repository.Entity.Customer customer = new Repository.Entity.Customer();
            Customer customerDto = new Customer();
            customer = repository.GetCustomerById(id);
            customerDto = AutoMapper.Mapper.Map<Repository.Entity.Customer, Customer>(customer);
            return customerDto;
        }
    }
}
