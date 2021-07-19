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
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly AppDbContext dbContext;
        public ManufacturerRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void DeleteManufacturerById(int id)
        {
            Manufacturer manufacturer = dbContext.Manufacturers.Find(id);
            dbContext.Manufacturers.Remove(manufacturer);
            dbContext.SaveChanges();
        }

        public List<Manufacturer> GetAllManufacturers()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            List<Manufacturer> manufacturersNotInDb = new List<Manufacturer>();
            manufacturers = dbContext.Manufacturers.ToList();
            List<string> emails = new List<string>();
            emails = dbContext.Users.Select(m => m.Email).ToList();
            foreach (var manufacturer in manufacturers)
            {
                if (!emails.Contains(manufacturer.Email))
                {
                    manufacturersNotInDb.Add(manufacturer);
                }
                else
                {
                    continue;
                }
            }

            return manufacturersNotInDb;
        }

        public Manufacturer GetManufacturerById(int id)
        {
            var manufacturer = dbContext.Manufacturers.SingleOrDefault(m => m.Id == id);

            return manufacturer;
        }

        public void PostManufacturer(Manufacturer manufacturer)
        {
            dbContext.Manufacturers.Add(manufacturer);
            dbContext.SaveChanges();

        }
        public void EditManufacturer(Manufacturer manufacturer)
        {
            dbContext.Entry(manufacturer).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public bool IsInDb(string email)
        {
            var obj = dbContext.Manufacturers.FirstOrDefault(m => m.Email == email);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
