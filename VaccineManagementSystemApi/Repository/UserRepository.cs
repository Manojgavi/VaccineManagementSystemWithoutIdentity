using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.Repository.Entity;
using VaccineManagementSystemApi.Repository.Context;
using System.Data.Entity;

namespace VaccineManagementSystemApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void DeleteUserById(int id)
        {
            User user = dbContext.Users.Find(id);
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            var users= dbContext.Users.ToList();
            
            return users;
        }

        public User GetUserById(int id)
        {
            var user = dbContext.Users.SingleOrDefault(m=>m.Id==id);
            
            return user;
        }

        public void PostUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

        }
        public void EditUser(User user)
        {
            dbContext.Entry(user).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
