using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Models;
using VaccineManagementSystemApi.Services;

namespace VaccineManagementSystem.Proxy
{
    public interface IUserRoleProxy
    {
        void PostUserRole(UserRole userRole);
        List<UserRole> GetAllUserRoles();
        void EditUserRole(UserRole userRole);
        void DeleteUserRoleById(int id);
        UserRole GetUserRoleById(int id);
        string[] GetRolesForUser(string email);
    }
}