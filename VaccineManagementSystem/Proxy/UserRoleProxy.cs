using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Models;
using VaccineManagementSystemApi.Services;
using VaccineManagementSystemApi;
using AutoMapper;

namespace VaccineManagementSystem.Proxy
{
    public class UserRoleProxy : IUserRoleProxy
    {
        private readonly IUserRoleCommandService userRoleCommandService;
        private readonly IUserRoleQueryService userRoleQueryService;
        public UserRoleProxy(IUserRoleCommandService userRoleCommandService, IUserRoleQueryService userRoleQueryService)
        {
            this.userRoleCommandService = userRoleCommandService;
            this.userRoleQueryService = userRoleQueryService;
        }
        public void PostUserRole(UserRole userRole)
        {

            VaccineManagementSystemApi.DTO.UserRole userRoleDto = new VaccineManagementSystemApi.DTO.UserRole();
            userRoleDto = AutoMapper.Mapper.Map<UserRole, VaccineManagementSystemApi.DTO.UserRole>(userRole);

            userRoleCommandService.PostUserRole(userRoleDto);
        }

        public List<UserRole> GetAllUserRoles()
        {
            List<VaccineManagementSystemApi.DTO.UserRole> userRoleDtoList = new List<VaccineManagementSystemApi.DTO.UserRole>();
            userRoleDtoList = userRoleQueryService.GetAllUserRoles();
            List<UserRole> userRole = new List<UserRole>();
            foreach (var userRoleDto in userRoleDtoList)
            {
                userRole.Add(Mapper.Map<VaccineManagementSystemApi.DTO.UserRole, UserRole>(userRoleDto));
            }
            return userRole;

        }

        public void EditUserRole(UserRole userRole)
        {

            VaccineManagementSystemApi.DTO.UserRole userRoleDto = new VaccineManagementSystemApi.DTO.UserRole();
            userRoleDto = AutoMapper.Mapper.Map<UserRole, VaccineManagementSystemApi.DTO.UserRole>(userRole);

            userRoleCommandService.EditUserRole(userRoleDto);
        }

        public void DeleteUserRoleById(int id)
        {


            userRoleCommandService.DeleteUserRoleById(id);
        }

        public UserRole GetUserRoleById(int id)
        {

            var userRoleDto = userRoleQueryService.GetUserRoleById(id);
            UserRole userRole = new UserRole();

            userRole = Mapper.Map<VaccineManagementSystemApi.DTO.UserRole, UserRole>(userRoleDto);

            return userRole;
        }

        public string[] GetRolesForUser(string email)
        {
            string[] result = userRoleQueryService.GetRolesForUser(email);
            return result;
        }
    }
}