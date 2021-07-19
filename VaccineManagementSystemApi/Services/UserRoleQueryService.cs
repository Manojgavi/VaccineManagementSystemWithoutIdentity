using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class UserRoleQueryService : IUserRoleQueryService
    {
        private readonly IUserRoleRepository repository;
        public UserRoleQueryService(IUserRoleRepository repository)
        {
            this.repository = repository;
        }
        public List<UserRole> GetAllUserRoles()
        {
            List<Repository.Entity.UserRole> userRoles = new List<Repository.Entity.UserRole>();

            userRoles = repository.GetAllUserRoles();
            List<UserRole> userRoleDto = new List<UserRole>();
            foreach (var userRole in userRoles)
            {
                userRoleDto.Add(AutoMapper.Mapper.Map<Repository.Entity.UserRole, UserRole>(userRole));
            }

            return userRoleDto;
        }

        public string[] GetRolesForUser(string email)
        {
            string[] result = repository.GetRolesForUser(email);
            return result;
        }

        public UserRole GetUserRoleById(int id)
        {
            Repository.Entity.UserRole userRole = new Repository.Entity.UserRole();
            UserRole userRoleDto = new UserRole();
            userRole = repository.GetUserRoleById(id);
            userRoleDto = AutoMapper.Mapper.Map<Repository.Entity.UserRole, UserRole>(userRole);
            return userRoleDto;
        }
    }
}
