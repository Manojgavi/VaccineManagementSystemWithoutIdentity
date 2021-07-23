using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystem.Proxy;
using VaccineManagementSystem.Models;
using VaccineManagementSystem.ControllerService;
using Xunit;

namespace VaccinManagementSystem.Test.MVC.ControllerService
{
    public class AccountControllerServiceTests
    {
        public void Login_LoginFound_ReturnsTrue()
        {
            List<User> users = new List<User>();
            User user = new User()
            {
                Email = "manojkumargavireddygari@gmail.com",
                Password = "Manoj@1234"
            };
            users.Add(user);

            VaccineManagementSystem.ViewModel.LoginViewModel loginViewModel = new VaccineManagementSystem.ViewModel.LoginViewModel()
            {
                Email = "manojkumargavireddygari@gmail.com",
                Password = "Manoj@1234"
            };
            
            var mockProxy = new Mock<IUserProxy>();
            var mockRoleProxy = new Mock<IUserRoleProxy>();
            mockProxy.Setup(m => m.GetAllUsers()).Returns(users);
            

            var sut = new AccountControllerService(mockProxy.Object,mockRoleProxy.Object);

            var result = sut.Login(loginViewModel);

            Assert.True(result);
        }
    }
}
