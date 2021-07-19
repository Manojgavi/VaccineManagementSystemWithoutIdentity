using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class HospitalCommandService : IHospitalCommandService
    {
        private readonly IHospitalRepository repository;
        public HospitalCommandService(IHospitalRepository repository)
        {
            this.repository = repository;
        }
        public void DeleteHospitalById(int id)
        {
            repository.DeleteHospitalById(id);
        }

        public void EditHospital(Hospital hospitalDto)
        {
            Repository.Entity.Hospital hospital = new Repository.Entity.Hospital();
            hospital = AutoMapper.Mapper.Map<Hospital, Repository.Entity.Hospital>(hospitalDto);
            repository.EditHospital(hospital);
        }

        public void PostHospital(Hospital hospitalDto)
        {
            Repository.Entity.Hospital hospital = new Repository.Entity.Hospital();
            hospital = AutoMapper.Mapper.Map<Hospital, Repository.Entity.Hospital>(hospitalDto);
            repository.PostHospital(hospital);
        }
    }
}
