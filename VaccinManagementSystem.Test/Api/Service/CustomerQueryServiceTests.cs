using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.Repository;
using VaccineManagementSystemApi.Repository.Entity;
using VaccineManagementSystemApi.Services;
using Xunit;

namespace VaccinManagementSystem.Test.Api.Service
{
    public class CustomerQueryServiceTests
    {
        //TestMethodName_Scenario_ExpectedBehaviour
        [Fact]
        public void GetCustomerById_CustomerFound_ReturnsCustomerDto()
        {
            //Arrange
            //Call SUT - systeme under test
            //Assert the result

            //Arrange
            var customerId = 23424;
            var customer = new Customer
            {
                Name = "Jai",
                Email = "someemail@email.com"
            };

            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(m => m.GetCustomerById(customerId)).Returns(customer);

            //SUT
            var sut = new CustomerQueryService(mockRepository.Object);

            var result = sut.GetCustomerById(customerId);

            Assert.NotNull(result);
        }
        [Fact]
        public void GetCustomerById_CustomerNotFound_ReturnsNull()
        {
            //Arrange
            //Call SUT - systeme under test
            //Assert the result

            //Arrange
            var customerId = 23424;
            Customer customer = null;
            var mockRepository = new Mock<ICustomerRepository>();
            //mockRepository.Setup(m => m.GetCustomerById(customerId)).Verifiable();
            mockRepository.Setup(m => m.GetCustomerById(customerId)).Returns(customer);
            //SUT
            var sut = new CustomerQueryService(mockRepository.Object);

            var result = sut.GetCustomerById(customerId);

            Assert.Null(result);
            //mockRepository.VerifyAll();
        }
        [Fact]
        public void GetCustomersByHospitalId_CustomersFound_ReturnsCustomers()
        {
            Customer customer = new Customer()
            {
                Id = 1,
                Name = "Manoj Kumar",
                AadharNumber = "544859137325",
                HospitalId=1

            };
            List<Customer> customers = new List<Customer>();
            customers.Add(customer);
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(m => m.GetCustomersByHospitalId(1)).Returns(customers);
            var sut = new CustomerQueryService(mockRepository.Object);
            var result = sut.GetCustomersByHospitalId(1);
            Assert.NotNull(result);
        }
    }
}
