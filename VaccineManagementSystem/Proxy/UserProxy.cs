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
    public class UserProxy : IUserProxy
    {
        private readonly IUserCommandService userCommandService;
        private readonly IUserQueryService userQueryService;
        public UserProxy(IUserCommandService userCommandService, IUserQueryService userQueryService)
        {
            this.userCommandService = userCommandService;
            this.userQueryService = userQueryService;
        }
        public void PostUser(User user)
        {
            
            VaccineManagementSystemApi.DTO.User userDto = new VaccineManagementSystemApi.DTO.User();
            userDto = AutoMapper.Mapper.Map<User, VaccineManagementSystemApi.DTO.User>(user);

            userCommandService.PostUser(userDto);
        }

        public List<User> GetAllUsers()
        {
            List<VaccineManagementSystemApi.DTO.User> userDtoList = new List<VaccineManagementSystemApi.DTO.User>();
            userDtoList = userQueryService.GetAllUsers();
            List<User> user = new List<User>();
            foreach (var userDto in userDtoList)
            {
                user.Add(Mapper.Map<VaccineManagementSystemApi.DTO.User, User>(userDto));
            }
            return user;

        }

        public void EditUser(User user)
        {
            
            VaccineManagementSystemApi.DTO.User userDto = new VaccineManagementSystemApi.DTO.User();
            userDto = AutoMapper.Mapper.Map<User, VaccineManagementSystemApi.DTO.User>(user);

            userCommandService.EditUser(userDto);
        }

        public void DeleteUserById(int id)
        {
           

            userCommandService.DeleteUserById(id);
        }

        public User GetUserById(int id)
        {
            
            var userDto = userQueryService.GetUserById(id);
            User user = new User();

            user = Mapper.Map<VaccineManagementSystemApi.DTO.User, User>(userDto);

            return user;
        }
    }
}