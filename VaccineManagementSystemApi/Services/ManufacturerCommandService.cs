using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.DTO;
using VaccineManagementSystemApi.Repository;

namespace VaccineManagementSystemApi.Services
{
    public class ManufacturerCommandService : IManufacturerCommandService
    {
        private readonly IManufacturerRepository repository;
        public ManufacturerCommandService(IManufacturerRepository repository)
        {
            this.repository = repository;
        }
        public void DeleteManufacturerById(int id)
        {
            repository.DeleteManufacturerById(id);
        }

        public void EditManufacturer(Manufacturer manufacturerDto)
        {
            Repository.Entity.Manufacturer manufacturer = new Repository.Entity.Manufacturer();
            manufacturer = AutoMapper.Mapper.Map<Manufacturer, Repository.Entity.Manufacturer>(manufacturerDto);
            repository.EditManufacturer(manufacturer);
        }

        public void PostManufacturer(Manufacturer manufacturerDto)
        {
            Repository.Entity.Manufacturer manufacturer = new Repository.Entity.Manufacturer();
            manufacturer = AutoMapper.Mapper.Map<Manufacturer, Repository.Entity.Manufacturer>(manufacturerDto);
            repository.PostManufacturer(manufacturer);
        }
    }
}
