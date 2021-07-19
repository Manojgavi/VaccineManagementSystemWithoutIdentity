using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class VaccineTypeCommandService : IVaccineTypeCommandService
    {
        private readonly IVaccineTypeRepository repository;
        public VaccineTypeCommandService(IVaccineTypeRepository repository)
        {
            this.repository = repository;
        }
        public void DeleteVaccineTypeById(int id)
        {
            repository.DeleteVaccineTypeById(id);
        }

        public void EditVaccineType(VaccineType vaccineTypeDto)
        {
            Repository.Entity.VaccineType vaccineType = new Repository.Entity.VaccineType();
            vaccineType = AutoMapper.Mapper.Map<VaccineType, Repository.Entity.VaccineType>(vaccineTypeDto);
            repository.EditVaccineType(vaccineType);
        }

        public void PostVaccineType(VaccineType vaccineTypeDto)
        {
            Repository.Entity.VaccineType vaccineType = new Repository.Entity.VaccineType();
            vaccineType = AutoMapper.Mapper.Map<VaccineType, Repository.Entity.VaccineType>(vaccineTypeDto);
            repository.PostVaccineType(vaccineType);
        }
    }
}
