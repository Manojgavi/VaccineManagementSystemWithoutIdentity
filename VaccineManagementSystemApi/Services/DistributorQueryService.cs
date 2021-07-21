using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class DistributorQueryService : IDistributorQueryService
    {
        private readonly IDistributorRepository repository;
        public DistributorQueryService(IDistributorRepository repository)
        {
            this.repository = repository;
        }
        public List<Distributor> GetAllDistributors()
        {
            List<Repository.Entity.Distributor> distributors = new List<Repository.Entity.Distributor>();

            distributors = repository.GetAllDistributors();
            List<Distributor> distributorDto = new List<Distributor>();
            foreach (var distributor in distributors)
            {
                distributorDto.Add(AutoMapper.Mapper.Map<Repository.Entity.Distributor, Distributor>(distributor));
            }

            return distributorDto;
        }
        public List<Distributor> GetAvailDistributors()
        {
            List<Repository.Entity.Distributor> distributors = new List<Repository.Entity.Distributor>();

            distributors = repository.GetAvailDistributors();
            List<Distributor> distributorDto = new List<Distributor>();
            foreach (var distributor in distributors)
            {
                distributorDto.Add(AutoMapper.Mapper.Map<Repository.Entity.Distributor, Distributor>(distributor));
            }

            return distributorDto;
        }

        public Distributor GetDistributorById(int id)
        {
            Repository.Entity.Distributor distributor = new Repository.Entity.Distributor();
            Distributor distributorDto = new Distributor();
            distributor = repository.GetDistributorById(id);
            distributorDto = AutoMapper.Mapper.Map<Repository.Entity.Distributor, Distributor>(distributor);
            return distributorDto;
        }
        public List<string> GetLocations()
        {
            List<string> locations = new List<string>();
            locations = repository.GetLocations();
            return locations;
        }
        public bool IsInDb(string email)
        {
            return repository.IsInDb(email);
        }
    }
}
