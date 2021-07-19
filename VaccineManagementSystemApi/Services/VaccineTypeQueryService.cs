using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class VaccineTypeQueryService : IVaccineTypeQueryService
    {
        private readonly IVaccineTypeRepository repository;
        public VaccineTypeQueryService(IVaccineTypeRepository repository)
        {
            this.repository = repository;
        }
        public List<VaccineType> GetAllVaccineTypes()
        {
            List<Repository.Entity.VaccineType> vaccineTypes = new List<Repository.Entity.VaccineType>();

            vaccineTypes = repository.GetAllVaccineTypes();
            List<VaccineType> vaccineTypeDto = new List<VaccineType>();
            foreach (var vaccineType in vaccineTypes)
            {
                vaccineTypeDto.Add(AutoMapper.Mapper.Map<Repository.Entity.VaccineType, VaccineType>(vaccineType));
            }

            return vaccineTypeDto;
        }

        public VaccineType GetVaccineTypeById(int id)
        {
            Repository.Entity.VaccineType vaccineType = new Repository.Entity.VaccineType();
            VaccineType vaccineTypeDto = new VaccineType();
            vaccineType = repository.GetVaccineTypeById(id);
            vaccineTypeDto = AutoMapper.Mapper.Map<Repository.Entity.VaccineType, VaccineType>(vaccineType);
            return vaccineTypeDto;
        }
    }
}
