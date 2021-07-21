using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class HospitalQueryService : IHospitalQueryService
    {
        private readonly IHospitalRepository repository;
        public HospitalQueryService(IHospitalRepository repository)
        {
            this.repository = repository;
        }
        public List<Hospital> GetAllHospitals()
        {
            List<Repository.Entity.Hospital> hospitals = new List<Repository.Entity.Hospital>();

            hospitals = repository.GetAllHospitals();
            List<Hospital> hospitalDto = new List<Hospital>();
            foreach (var hospital in hospitals)
            {
                hospitalDto.Add(AutoMapper.Mapper.Map<Repository.Entity.Hospital, Hospital>(hospital));
            }

            return hospitalDto;
        }
        public List<Hospital> GetAvailHospitals()
        {
            List<Repository.Entity.Hospital> hospitals = new List<Repository.Entity.Hospital>();

            hospitals = repository.GetAvailHospitals();
            List<Hospital> hospitalDto = new List<Hospital>();
            foreach (var hospital in hospitals)
            {
                hospitalDto.Add(AutoMapper.Mapper.Map<Repository.Entity.Hospital, Hospital>(hospital));
            }

            return hospitalDto;
        }

        public Hospital GetHospitalById(int id)
        {
            Repository.Entity.Hospital hospital = new Repository.Entity.Hospital();
            Hospital hospitalDto = new Hospital();
            hospital = repository.GetHospitalById(id);
            hospitalDto = AutoMapper.Mapper.Map<Repository.Entity.Hospital, Hospital>(hospital);
            return hospitalDto;
        }
        public Hospital GetHospitalByEmail(string email)
        {
            Repository.Entity.Hospital hospital = new Repository.Entity.Hospital();
            Hospital hospitalDto = new Hospital();
            hospital = repository.GetHospitalByEmail(email);
            hospitalDto = AutoMapper.Mapper.Map<Repository.Entity.Hospital, Hospital>(hospital);
            return hospitalDto;
        }
        public bool IsInDb(string email)
        {
            return repository.IsInDb(email);
        }
    }
}
