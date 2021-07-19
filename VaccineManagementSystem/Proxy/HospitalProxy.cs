using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Models;
using VaccineManagementSystemApi.Services;
using VaccineManagementSystemApi;
using AutoMapper;

namespace VaccineManagementSystem.Proxy
{
    public class HospitalProxy : IHospitalProxy
    {
        private readonly IHospitalCommandService hospitalCommandService;
        private readonly IHospitalQueryService hospitalQueryService;
        public HospitalProxy(IHospitalCommandService hospitalCommandService, IHospitalQueryService hospitalQueryService)
        {
            this.hospitalCommandService = hospitalCommandService;
            this.hospitalQueryService = hospitalQueryService;
        }
        public void PostHospital(Hospital hospital)
        {

            VaccineManagementSystemApi.DTO.Hospital hospitalDto = new VaccineManagementSystemApi.DTO.Hospital();
            hospitalDto = AutoMapper.Mapper.Map<Hospital, VaccineManagementSystemApi.DTO.Hospital>(hospital);

            hospitalCommandService.PostHospital(hospitalDto);
        }

        public List<Hospital> GetAllHospitals()
        {
            List<VaccineManagementSystemApi.DTO.Hospital> hospitalDtoList = new List<VaccineManagementSystemApi.DTO.Hospital>();
            hospitalDtoList = hospitalQueryService.GetAllHospitals();
            List<Hospital> hospital = new List<Hospital>();
            foreach (var hospitalDto in hospitalDtoList)
            {
                hospital.Add(Mapper.Map<VaccineManagementSystemApi.DTO.Hospital, Hospital>(hospitalDto));
            }
            return hospital;

        }

        public void EditHospital(Hospital hospital)
        {

            VaccineManagementSystemApi.DTO.Hospital hospitalDto = new VaccineManagementSystemApi.DTO.Hospital();
            hospitalDto = AutoMapper.Mapper.Map<Hospital, VaccineManagementSystemApi.DTO.Hospital>(hospital);

            hospitalCommandService.EditHospital(hospitalDto);
        }

        public void DeleteHospitalById(int id)
        {


            hospitalCommandService.DeleteHospitalById(id);
        }

        public Hospital GetHospitalById(int id)
        {

            var hospitalDto = hospitalQueryService.GetHospitalById(id);
            Hospital hospital = new Hospital();

            hospital = Mapper.Map<VaccineManagementSystemApi.DTO.Hospital, Hospital>(hospitalDto);

            return hospital;
        }
    }
}