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
    public class DistributorRepository : IDistributorRepository
    {
        private readonly AppDbContext dbContext;
        public DistributorRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void DeleteDistributorById(int id)
        {
            Distributor distributor = dbContext.Distributors.Find(id);
            dbContext.Distributors.Remove(distributor);
            dbContext.SaveChanges();
        }

        public List<Distributor> GetAllDistributors()
        {
            List<Distributor> distributors = new List<Distributor>();
            List<Distributor> distributorsNotInDb = new List<Distributor>();
            distributors = dbContext.Distributors.ToList();
            List<string> emails = new List<string>();
            emails = dbContext.Users.Select(m => m.Email).ToList();
            foreach(var distributor in distributors)
            {
                if(!emails.Contains(distributor.Email))
                {
                    distributorsNotInDb.Add(distributor);
                }
                else
                {
                    continue;
                }
            }
            
            return distributorsNotInDb;
        }
        public List<Distributor> GetAvailDistributors()
        {
            List<Distributor> distributors = new List<Distributor>();
            List<Distributor> distributorsNotInDb = new List<Distributor>();
            distributors = dbContext.Distributors.ToList();
            List<string> emails = new List<string>();
            emails = dbContext.Users.Select(m => m.Email).ToList();
            foreach (var distributor in distributors)
            {
                if (emails.Contains(distributor.Email))
                {
                    distributorsNotInDb.Add(distributor);
                }
                else
                {
                    continue;
                }
            }

            return distributorsNotInDb;
        }
        //public List<Distributor> GetAllDistributors()
        //{
        //    var distributors = dbContext.Distributors.ToList();

        //    return distributors;
        //}

        public Distributor GetDistributorById(int id)
        {
            var distributor = dbContext.Distributors.SingleOrDefault(m => m.Id == id);

            return distributor;
        }

        public void PostDistributor(Distributor distributor)
        {
            dbContext.Distributors.Add(distributor);
            dbContext.SaveChanges();

        }
        public void EditDistributor(Distributor distributor)
        {
            dbContext.Entry(distributor).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public List<string> GetLocations()
        {
            List<Hospital> hospitals = new List<Hospital>();
            List<string> users = new List<string>();
            List<string> locations = new List<string>();
            users = dbContext.Users.Select(m => m.Email).ToList();
            hospitals=dbContext.Hospitals.ToList();
            foreach(var hospital in hospitals)
            {
                if(users.Contains(hospital.Email))
                {
                    locations.Add(hospital.Location);
                }
            }
            return locations;
        }
        public Distributor GetDistributorByEmail(string email)
        {
            Distributor obj = new Distributor();
            obj = dbContext.Distributors.FirstOrDefault(m => m.Email == email);
            return obj;
        }
       
        public bool IsInDb(string email)
        {
            var obj = dbContext.Distributors.FirstOrDefault(m => m.Email == email);
            if(obj==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void UpdateHospitalOrdersById(int id)
        {
            HospitalOrders hospitalOrders=dbContext.HospitalOrders.Find(id);
            hospitalOrders.Status = "Delivered";
            dbContext.SaveChanges();
        }
    }
}
