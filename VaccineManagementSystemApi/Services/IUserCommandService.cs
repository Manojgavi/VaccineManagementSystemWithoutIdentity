using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;

namespace VaccineManagementSystemApi.Services
{
    public interface IUserCommandService
    {
        void PostUser(User user);
        void DeleteUserById(int id);
        void EditUser(User user);
    }
}
