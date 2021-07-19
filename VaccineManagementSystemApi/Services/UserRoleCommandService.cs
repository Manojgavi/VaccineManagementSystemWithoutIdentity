using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class UserRoleCommandService : IUserRoleCommandService
    {
        private readonly IUserRoleRepository repository;
        public UserRoleCommandService(IUserRoleRepository repository)
        {
            this.repository = repository;
        }
        public void DeleteUserRoleById(int id)
        {
            repository.DeleteUserRoleById(id);
        }

        public void EditUserRole(UserRole userRoleDto)
        {
            Repository.Entity.UserRole userRole = new Repository.Entity.UserRole();
            userRole = AutoMapper.Mapper.Map<UserRole, Repository.Entity.UserRole>(userRoleDto);
            repository.EditUserRole(userRole);
        }

        public void PostUserRole(UserRole userRoleDto)
        {
            Repository.Entity.UserRole userRole = new Repository.Entity.UserRole();
            userRole = AutoMapper.Mapper.Map<UserRole, Repository.Entity.UserRole>(userRoleDto);
            repository.PostUserRole(userRole);
        }
    }
}
