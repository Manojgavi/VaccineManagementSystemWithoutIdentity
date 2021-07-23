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
    public class DistributorProxy : IDistributorProxy
    {
        private readonly IDistributorCommandService distributorCommandService;
        private readonly IDistributorQueryService distributorQueryService;
        public DistributorProxy(IDistributorCommandService distributorCommandService, IDistributorQueryService distributorQueryService)
        {
            this.distributorCommandService = distributorCommandService;
            this.distributorQueryService = distributorQueryService;
        }
        public void PostDistributor(Distributor distributor)
        {

            VaccineManagementSystemApi.DTO.Distributor distributorDto = new VaccineManagementSystemApi.DTO.Distributor();
            distributorDto = AutoMapper.Mapper.Map<Distributor, VaccineManagementSystemApi.DTO.Distributor>(distributor);

            distributorCommandService.PostDistributor(distributorDto);
        }

        public List<Distributor> GetAllDistributors()
        {
            List<VaccineManagementSystemApi.DTO.Distributor> distributorDtoList = new List<VaccineManagementSystemApi.DTO.Distributor>();
            distributorDtoList = distributorQueryService.GetAllDistributors();
            List<Distributor> distributor = new List<Distributor>();
            foreach (var distributorDto in distributorDtoList)
            {
                distributor.Add(Mapper.Map<VaccineManagementSystemApi.DTO.Distributor, Distributor>(distributorDto));
            }
            return distributor;

        }
        public List<Distributor> GetAvailDistributors()
        {
            List<VaccineManagementSystemApi.DTO.Distributor> distributorDtoList = new List<VaccineManagementSystemApi.DTO.Distributor>();
            distributorDtoList = distributorQueryService.GetAvailDistributors();
            List<Distributor> distributor = new List<Distributor>();
            foreach (var distributorDto in distributorDtoList)
            {
                distributor.Add(Mapper.Map<VaccineManagementSystemApi.DTO.Distributor, Distributor>(distributorDto));
            }
            return distributor;

        }

        public void EditDistributor(Distributor distributor)
        {

            VaccineManagementSystemApi.DTO.Distributor distributorDto = new VaccineManagementSystemApi.DTO.Distributor();
            distributorDto = AutoMapper.Mapper.Map<Distributor, VaccineManagementSystemApi.DTO.Distributor>(distributor);

            distributorCommandService.EditDistributor(distributorDto);
        }

        public void DeleteDistributorById(int id)
        {


            distributorCommandService.DeleteDistributorById(id);
        }

        public Distributor GetDistributorById(int id)
        {

            var distributorDto = distributorQueryService.GetDistributorById(id);
            Distributor distributor = new Distributor();

            distributor = Mapper.Map<VaccineManagementSystemApi.DTO.Distributor, Distributor>(distributorDto);

            return distributor;
        }
        public List<string> GetLocations()
        {
            List<string> locations = new List<string>();
            locations = distributorQueryService.GetLocations();
            return locations;
        }
        public Distributor GetDistributorByEmail(string email)
        {

            var distributorDto = distributorQueryService.GetDistributorByEmail(email);
            Distributor distributor = new Distributor();

            distributor = Mapper.Map<VaccineManagementSystemApi.DTO.Distributor, Distributor>(distributorDto);

            return distributor;
        }
        public bool IsInDb(string email)
        {
            return distributorQueryService.IsInDb(email);
        }

        public void UpdateHospitalOrdersById(int id)
        {
            distributorCommandService.UpdateHospitalOrdersById(id);
        }
    }
}