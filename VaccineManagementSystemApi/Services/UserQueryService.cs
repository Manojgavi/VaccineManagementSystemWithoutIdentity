using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class UserQueryService : IUserQueryService
    {
        private readonly IUserRepository repository;
        public UserQueryService(IUserRepository repository)
        {
            this.repository = repository;
        }
        public List<User> GetAllUsers()
        {
            List<Repository.Entity.User> users = new List<Repository.Entity.User>();
            
            users = repository.GetAllUsers();
            List<User> userDto = new List<User>();
            foreach (var user in users)
            {
                userDto.Add(AutoMapper.Mapper.Map<Repository.Entity.User, User>(user));
            }

            return userDto;
        }

        public User GetUserById(int id)
        {
            Repository.Entity.User user = new Repository.Entity.User();
            User userDto = new User();
            user=repository.GetUserById(id);
            userDto = AutoMapper.Mapper.Map<Repository.Entity.User, User>(user);
            return userDto;
        }
    }
}
