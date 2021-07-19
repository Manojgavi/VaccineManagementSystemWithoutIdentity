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
    public class ManufacturerProxy : IManufacturerProxy
    {
        private readonly IManufacturerCommandService manufacturerCommandService;
        private readonly IManufacturerQueryService manufacturerQueryService;
        public ManufacturerProxy(IManufacturerCommandService manufacturerCommandService, IManufacturerQueryService manufacturerQueryService)
        {
            this.manufacturerCommandService = manufacturerCommandService;
            this.manufacturerQueryService = manufacturerQueryService;
        }
        public void PostManufacturer(Manufacturer manufacturer)
        {

            VaccineManagementSystemApi.DTO.Manufacturer manufacturerDto = new VaccineManagementSystemApi.DTO.Manufacturer();
            manufacturerDto = AutoMapper.Mapper.Map<Manufacturer, VaccineManagementSystemApi.DTO.Manufacturer>(manufacturer);

            manufacturerCommandService.PostManufacturer(manufacturerDto);
        }

        public List<Manufacturer> GetAllManufacturers()
        {
            List<VaccineManagementSystemApi.DTO.Manufacturer> manufacturerDtoList = new List<VaccineManagementSystemApi.DTO.Manufacturer>();
            manufacturerDtoList = manufacturerQueryService.GetAllManufacturers();
            List<Manufacturer> manufacturer = new List<Manufacturer>();
            foreach (var manufacturerDto in manufacturerDtoList)
            {
                manufacturer.Add(Mapper.Map<VaccineManagementSystemApi.DTO.Manufacturer, Manufacturer>(manufacturerDto));
            }
            return manufacturer;

        }

        public void EditManufacturer(Manufacturer manufacturer)
        {

            VaccineManagementSystemApi.DTO.Manufacturer manufacturerDto = new VaccineManagementSystemApi.DTO.Manufacturer();
            manufacturerDto = AutoMapper.Mapper.Map<Manufacturer, VaccineManagementSystemApi.DTO.Manufacturer>(manufacturer);

            manufacturerCommandService.EditManufacturer(manufacturerDto);
        }

        public void DeleteManufacturerById(int id)
        {


            manufacturerCommandService.DeleteManufacturerById(id);
        }

        public Manufacturer GetManufacturerById(int id)
        {

            var manufacturerDto = manufacturerQueryService.GetManufacturerById(id);
            Manufacturer manufacturer = new Manufacturer();

            manufacturer = Mapper.Map<VaccineManagementSystemApi.DTO.Manufacturer, Manufacturer>(manufacturerDto);

            return manufacturer;
        }
        public bool IsInDb(string email)
        {
            return manufacturerQueryService.IsInDb(email);
        }
    }
}