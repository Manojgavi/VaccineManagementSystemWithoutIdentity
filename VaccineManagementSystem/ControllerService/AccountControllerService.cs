using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.ViewModel;
using VaccineManagementSystem.Proxy;
using System.Web.Mvc;

namespace VaccineManagementSystem.ControllerService
{
    
    public class AccountControllerService : IAccountControllerService
    {
        private readonly IUserProxy userProxy;
        private readonly IUserRoleProxy userRoleProxy;
        public AccountControllerService(IUserProxy userProxy, IUserRoleProxy userRoleProxy)
        {
            this.userProxy = userProxy;
            this.userRoleProxy = userRoleProxy;
        }
        public List<Models.User> GetUsers()
        {
            List<Models.User> users = new List<Models.User>();
            users = userProxy.GetAllUsers();
            return users;
        }
        public void DeleteUserById(int id)
        {
            userProxy.DeleteUserById(id);
        }
        public bool Login(LoginViewModel loginViewModel)
        {
            int i = 0;
            var users = userProxy.GetAllUsers();
            foreach(var user in users)
            {
                if(user.Email==loginViewModel.Email&&user.Password==loginViewModel.Password)
                {
                    i = 1;
                    break;
                }
                else
                {
                    i = 0;
                }

            }
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PostUSer(RegisterViewModel registerViewModel)
        {
            Models.User user = new Models.User()
            {
                Id = registerViewModel.Id,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password,
                UserRoleID = registerViewModel.UserRoleId
            };
            
            userProxy.PostUser(user);
        }



        public RegisterViewModel Register()
        {
            List<UserRole> userRoleView = new List<UserRole>();
            List<Models.UserRole> userRoles = new List<Models.UserRole>();
            ViewModel.User userView = new ViewModel.User();
            userRoles = userRoleProxy.GetAllUserRoles();
            //userView = AutoMapper.Mapper.Map<Models.User, ViewModel.User>(user);
            foreach (var userRole in userRoles)
            {
                userRoleView.Add(AutoMapper.Mapper.Map<Models.UserRole, ViewModel.UserRole>(userRole));
            }
            RegisterViewModel registerViewModel = new RegisterViewModel()
            {

                UserRole = userRoleView

            };
            return registerViewModel;

        }
    }
}