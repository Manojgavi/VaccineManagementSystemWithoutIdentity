using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.Repository.Entity;

namespace VaccineManagementSystemApi.Repository
{
    public interface IUserRoleRepository
    {
        UserRole GetUserRoleById(int id);
        List<UserRole> GetAllUserRoles();
        void PostUserRole(UserRole userRole);
        void DeleteUserRoleById(int id);
        void EditUserRole(UserRole userRole);
        string[] GetRolesForUser(string email);
    }
}
