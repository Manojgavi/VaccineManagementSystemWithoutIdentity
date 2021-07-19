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
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly AppDbContext dbContext;
        public UserRoleRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void DeleteUserRoleById(int id)
        {
            UserRole userRole = dbContext.UserRoles.Find(id);
            dbContext.UserRoles.Remove(userRole);
            dbContext.SaveChanges();
        }

        public List<UserRole> GetAllUserRoles()
        {
            var userRoles = dbContext.UserRoles.ToList();

            return userRoles;
        }

        public UserRole GetUserRoleById(int id)
        {
            var userRole = dbContext.UserRoles.SingleOrDefault(m => m.Id == id);

            return userRole;
        }

        public void PostUserRole(UserRole userRole)
        {
            dbContext.UserRoles.Add(userRole);
            dbContext.SaveChanges();

        }
        public void EditUserRole(UserRole userRole)
        {
            dbContext.Entry(userRole).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public string[] GetRolesForUser(string email)
        {
            
              var userRoles = (from user in dbContext.Users
                                 join role in dbContext.UserRoles
                                 on user.UserRoleId equals role.Id                               
                                 where user.Email == email
                                 select role.Role).ToArray();
                return userRoles;
            
        }

       
    }
}
