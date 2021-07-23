using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class DistributorCommandService : IDistributorCommandService
    {
        private readonly IDistributorRepository repository;
        public DistributorCommandService(IDistributorRepository repository)
        {
            this.repository = repository;
        }
        public void DeleteDistributorById(int id)
        {
            repository.DeleteDistributorById(id);
        }

        public void EditDistributor(Distributor distributorDto)
        {
            Repository.Entity.Distributor distributor = new Repository.Entity.Distributor();
            distributor = AutoMapper.Mapper.Map<Distributor, Repository.Entity.Distributor>(distributorDto);
            repository.EditDistributor(distributor);
        }

        public void PostDistributor(Distributor distributorDto)
        {
            Repository.Entity.Distributor distributor = new Repository.Entity.Distributor();
            distributor = AutoMapper.Mapper.Map<Distributor, Repository.Entity.Distributor>(distributorDto);
            repository.PostDistributor(distributor);
        }

        public void UpdateHospitalOrdersById(int id)
        {
            repository.UpdateHospitalOrdersById(id);
        }
    }
}
