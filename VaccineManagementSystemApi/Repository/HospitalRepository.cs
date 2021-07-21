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
    public class HospitalRepository : IHospitalRepository
    {
        private readonly AppDbContext dbContext;
        public HospitalRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void DeleteHospitalById(int id)
        {
            Hospital hospital = dbContext.Hospitals.Find(id);
            dbContext.Hospitals.Remove(hospital);
            dbContext.SaveChanges();
        }

        public List<Hospital> GetAllHospitals()
        {
            List<Hospital> hospitals = new List<Hospital>();
            List<Hospital> hospitalsNotInDb = new List<Hospital>();
            hospitals = dbContext.Hospitals.ToList();
            List<string> emails = new List<string>();
            emails = dbContext.Users.Select(m => m.Email).ToList();
            foreach (var hospital in hospitals)
            {
                if (!emails.Contains(hospital.Email))
                {
                    hospitalsNotInDb.Add(hospital);
                }
                else
                {
                    continue;
                }
            }

            return hospitalsNotInDb;
        }
        public List<Hospital> GetAvailHospitals()
        {
            List<Hospital> hospitals = new List<Hospital>();
            List<Hospital> hospitalsNotInDb = new List<Hospital>();
            hospitals = dbContext.Hospitals.ToList();
            List<string> emails = new List<string>();
            emails = dbContext.Users.Select(m => m.Email).ToList();
            foreach (var hospital in hospitals)
            {
                if (emails.Contains(hospital.Email))
                {
                    hospitalsNotInDb.Add(hospital);
                }
                else
                {
                    continue;
                }
            }

            return hospitalsNotInDb;
        }

        public Hospital GetHospitalById(int id)
        {
            var hospital = dbContext.Hospitals.SingleOrDefault(m => m.Id == id);

            return hospital;
        }

        public void PostHospital(Hospital hospital)
        {
            dbContext.Hospitals.Add(hospital);
            dbContext.SaveChanges();

        }
        public void EditHospital(Hospital hospital)
        {
            dbContext.Entry(hospital).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public Hospital GetHospitalByEmail(string email)
        {
            Hospital obj = new Hospital();
            obj = dbContext.Hospitals.FirstOrDefault(m => m.Email == email);
            return obj;
        }
        public bool IsInDb(string email)
        {
            var obj = dbContext.Hospitals.FirstOrDefault(m => m.Email == email);
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
