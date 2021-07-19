using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;

namespace VaccineManagementSystemApi.Services
{
    public interface IUserRoleCommandService
    {
        void PostUserRole(UserRole userRole);
        void DeleteUserRoleById(int id);
        void EditUserRole(UserRole userRole);
    }
}
