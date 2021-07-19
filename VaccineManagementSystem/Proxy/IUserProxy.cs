using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Models;
using VaccineManagementSystemApi.Services;

namespace VaccineManagementSystem.Proxy
{
    public interface IUserProxy
    {
        void PostUser(User user);
        List<User> GetAllUsers();
        void EditUser(User user);
        void DeleteUserById(int id);
        User GetUserById(int id);
    }
}