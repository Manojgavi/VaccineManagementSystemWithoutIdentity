using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class ManufacturerQueryService : IManufacturerQueryService
    {
        private readonly IManufacturerRepository repository;
        public ManufacturerQueryService(IManufacturerRepository repository)
        {
            this.repository = repository;
        }
        public List<Manufacturer> GetAllManufacturers()
        {
            List<Repository.Entity.Manufacturer> manufacturers = new List<Repository.Entity.Manufacturer>();

            manufacturers = repository.GetAllManufacturers();
            List<Manufacturer> manufacturerDto = new List<Manufacturer>();
            foreach (var manufacturer in manufacturers)
            {
                manufacturerDto.Add(AutoMapper.Mapper.Map<Repository.Entity.Manufacturer, Manufacturer>(manufacturer));
            }

            return manufacturerDto;
        }
        public List<Manufacturer> GetManufacturersByVaccineId(int id)
        {
            List<Repository.Entity.Manufacturer> manufacturers = new List<Repository.Entity.Manufacturer>();

            manufacturers = repository.GetManufacturersByVaccineId(id);
            List<Manufacturer> manufacturerDto = new List<Manufacturer>();
            foreach (var manufacturer in manufacturers)
            {
                manufacturerDto.Add(AutoMapper.Mapper.Map<Repository.Entity.Manufacturer, Manufacturer>(manufacturer));
            }

            return manufacturerDto;
        }
        public Manufacturer GetManufacturerByEmail(string email)
        {
            Repository.Entity.Manufacturer manufacturer = new Repository.Entity.Manufacturer();
            Manufacturer manufacturerDto = new Manufacturer();
            manufacturer = repository.GetManufacturerByEmail(email);
            manufacturerDto = AutoMapper.Mapper.Map<Repository.Entity.Manufacturer, Manufacturer>(manufacturer);
            return manufacturerDto;
        }

        public Manufacturer GetManufacturerById(int id)
        {
            Repository.Entity.Manufacturer manufacturer = new Repository.Entity.Manufacturer();
            Manufacturer manufacturerDto = new Manufacturer();
            manufacturer = repository.GetManufacturerById(id);
            manufacturerDto = AutoMapper.Mapper.Map<Repository.Entity.Manufacturer, Manufacturer>(manufacturer);
            return manufacturerDto;
        }
        public bool IsInDb(string email)
        {
            return repository.IsInDb(email);
        }
    }
}
