using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Models;
using VaccineManagementSystemApi.Services;
using VaccineManagementSystemApi;
using AutoMapper;

namespace VaccineManagementSystem.Proxy
{
    public class CustomerProxy : ICustomerProxy
    {
        private readonly ICustomerCommandService customerCommandService;
        private readonly ICustomerQueryService customerQueryService;
        public CustomerProxy(ICustomerCommandService customerCommandService, ICustomerQueryService customerQueryService)
        {
            this.customerCommandService = customerCommandService;
            this.customerQueryService = customerQueryService;
        }
        public void PostCustomer(Customer customer)
        {

            VaccineManagementSystemApi.DTO.Customer customerDto = new VaccineManagementSystemApi.DTO.Customer();
            customerDto = AutoMapper.Mapper.Map<Customer, VaccineManagementSystemApi.DTO.Customer>(customer);

            customerCommandService.PostCustomer(customerDto);
        }

        public List<Customer> GetAllCustomers()
        {
            List<VaccineManagementSystemApi.DTO.Customer> customerDtoList = new List<VaccineManagementSystemApi.DTO.Customer>();
            customerDtoList = customerQueryService.GetAllCustomers();
            List<Customer> customer = new List<Customer>();
            foreach (var customerDto in customerDtoList)
            {
                customer.Add(Mapper.Map<VaccineManagementSystemApi.DTO.Customer, Customer>(customerDto));
            }
            return customer;

        }
        public List<Customer> GetCustomersByHospitalId(int id)
        {
            List<VaccineManagementSystemApi.DTO.Customer> customerDtoList = new List<VaccineManagementSystemApi.DTO.Customer>();
            customerDtoList = customerQueryService.GetCustomersByHospitalId(id);
            List<Customer> customer = new List<Customer>();
            foreach (var customerDto in customerDtoList)
            {
                customer.Add(Mapper.Map<VaccineManagementSystemApi.DTO.Customer, Customer>(customerDto));
            }
            return customer;

        }

        public void EditCustomer(Customer customer)
        {

            VaccineManagementSystemApi.DTO.Customer customerDto = new VaccineManagementSystemApi.DTO.Customer();
            customerDto = AutoMapper.Mapper.Map<Customer, VaccineManagementSystemApi.DTO.Customer>(customer);

            customerCommandService.EditCustomer(customerDto);
        }

        public void DeleteCustomerById(int id)
        {


            customerCommandService.DeleteCustomerById(id);
        }
        public void UpdateStatus(int id,int status)
        {


            customerCommandService.UpdateStatus(id,status);
        }
        public Customer GetCustomerById(int id)
        {

            var customerDto = customerQueryService.GetCustomerById(id);
            Customer customer = new Customer();

            customer = Mapper.Map<VaccineManagementSystemApi.DTO.Customer, Customer>(customerDto);

            return customer;
        }
    }
}