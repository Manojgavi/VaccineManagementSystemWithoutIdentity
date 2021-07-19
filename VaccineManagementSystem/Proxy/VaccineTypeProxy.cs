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
    public class VaccineTypeProxy : IVaccineTypeProxy
    {
        private readonly IVaccineTypeCommandService vaccineTypeCommandService;
        private readonly IVaccineTypeQueryService vaccineTypeQueryService;
        public VaccineTypeProxy(IVaccineTypeCommandService vaccineTypeCommandService, IVaccineTypeQueryService vaccineTypeQueryService)
        {
            this.vaccineTypeCommandService = vaccineTypeCommandService;
            this.vaccineTypeQueryService = vaccineTypeQueryService;
        }
        public void PostVaccineType(VaccineType vaccineType)
        {

            VaccineManagementSystemApi.DTO.VaccineType vaccineTypeDto = new VaccineManagementSystemApi.DTO.VaccineType();
            vaccineTypeDto = AutoMapper.Mapper.Map<VaccineType, VaccineManagementSystemApi.DTO.VaccineType>(vaccineType);

            vaccineTypeCommandService.PostVaccineType(vaccineTypeDto);
        }

        public List<VaccineType> GetAllVaccineTypes()
        {
            List<VaccineManagementSystemApi.DTO.VaccineType> vaccineTypeDtoList = new List<VaccineManagementSystemApi.DTO.VaccineType>();
            vaccineTypeDtoList = vaccineTypeQueryService.GetAllVaccineTypes();
            List<VaccineType> vaccineType = new List<VaccineType>();
            foreach (var vaccineTypeDto in vaccineTypeDtoList)
            {
                vaccineType.Add(Mapper.Map<VaccineManagementSystemApi.DTO.VaccineType, VaccineType>(vaccineTypeDto));
            }
            return vaccineType;

        }

        public void EditVaccineType(VaccineType vaccineType)
        {

            VaccineManagementSystemApi.DTO.VaccineType vaccineTypeDto = new VaccineManagementSystemApi.DTO.VaccineType();
            vaccineTypeDto = AutoMapper.Mapper.Map<VaccineType, VaccineManagementSystemApi.DTO.VaccineType>(vaccineType);

            vaccineTypeCommandService.EditVaccineType(vaccineTypeDto);
        }

        public void DeleteVaccineTypeById(int id)
        {


            vaccineTypeCommandService.DeleteVaccineTypeById(id);
        }

        public VaccineType GetVaccineTypeById(int id)
        {

            var vaccineTypeDto = vaccineTypeQueryService.GetVaccineTypeById(id);
            VaccineType vaccineType = new VaccineType();

            vaccineType = Mapper.Map<VaccineManagementSystemApi.DTO.VaccineType, VaccineType>(vaccineTypeDto);

            return vaccineType;
        }
    }
}