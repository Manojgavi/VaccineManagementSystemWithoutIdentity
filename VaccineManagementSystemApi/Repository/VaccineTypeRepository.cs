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
    public class VaccineTypeRepository : IVaccineTypeRepository
    {
        private readonly AppDbContext dbContext;
        public VaccineTypeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void DeleteVaccineTypeById(int id)
        {
            VaccineType vaccineType = dbContext.VaccineTypes.Find(id);
            dbContext.VaccineTypes.Remove(vaccineType);
            dbContext.SaveChanges();
        }

        public List<VaccineType> GetAllVaccineTypes()
        {
            var vaccineTypes = dbContext.VaccineTypes.ToList();

            return vaccineTypes;
        }

        public VaccineType GetVaccineTypeById(int id)
        {
            var vaccineType = dbContext.VaccineTypes.SingleOrDefault(m => m.Id == id);

            return vaccineType;
        }

        public void PostVaccineType(VaccineType vaccineType)
        {
            dbContext.VaccineTypes.Add(vaccineType);
            dbContext.SaveChanges();

        }
        public void EditVaccineType(VaccineType vaccineType)
        {
            dbContext.Entry(vaccineType).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
