using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class CustomerCommandService : ICustomerCommandService
    {
        private readonly ICustomerRepository repository;
        public CustomerCommandService(ICustomerRepository repository)
        {
            this.repository = repository;
        }
        public void DeleteCustomerById(int id)
        {
            repository.DeleteCustomerById(id);
        }

        public void EditCustomer(Customer customerDto)
        {
            Repository.Entity.Customer customer = new Repository.Entity.Customer();
            customer = AutoMapper.Mapper.Map<Customer, Repository.Entity.Customer>(customerDto);
            repository.EditCustomer(customer);
        }

        public void PostCustomer(Customer customerDto)
        {
            Repository.Entity.Customer customer = new Repository.Entity.Customer();
            customer = AutoMapper.Mapper.Map<Customer, Repository.Entity.Customer>(customerDto);
            repository.PostCustomer(customer);
        }
    }
}
