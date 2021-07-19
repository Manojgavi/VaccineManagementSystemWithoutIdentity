using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.Repository.Entity;

namespace VaccineManagementSystemApi.Repository
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetAllUsers();
        void PostUser(User user);
        void DeleteUserById(int id);
        void EditUser(User user);
    }
}
