using AutoMapper;
namespace VaccineManagementSystem.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            Mapper.CreateMap<Models.Customer, VaccineManagementSystemApi.DTO.Customer>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.Customer, VaccineManagementSystem.Models.Customer>();
            Mapper.CreateMap<VaccineManagementSystem.Models.Hospital, VaccineManagementSystemApi.DTO.Hospital>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.Hospital, VaccineManagementSystem.Models.Hospital>();
            Mapper.CreateMap<VaccineManagementSystem.Models.VaccineType, VaccineManagementSystemApi.DTO.VaccineType>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.VaccineType, VaccineManagementSystem.Models.VaccineType>();
            Mapper.CreateMap<Models.Manufacturer, VaccineManagementSystemApi.DTO.Manufacturer>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.Manufacturer, VaccineManagementSystem.Models.Manufacturer>();
            Mapper.CreateMap<VaccineManagementSystem.Models.Distributor, VaccineManagementSystemApi.DTO.Distributor>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.Distributor, VaccineManagementSystem.Models.Distributor>();
            Mapper.CreateMap<VaccineManagementSystem.Models.User, VaccineManagementSystemApi.DTO.User>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.User, VaccineManagementSystem.Models.User>();
            Mapper.CreateMap<VaccineManagementSystem.Models.UserRole, VaccineManagementSystemApi.DTO.UserRole>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.UserRole, VaccineManagementSystem.Models.UserRole>();
            Mapper.CreateMap<VaccineManagementSystem.Models.HospitalOrders, VaccineManagementSystemApi.DTO.HospitalOrders>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.HospitalOrders, VaccineManagementSystem.Models.HospitalOrders>();


            Mapper.CreateMap<VaccineManagementSystemApi.Repository.Entity.UserRole, VaccineManagementSystemApi.DTO.UserRole>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.UserRole, VaccineManagementSystemApi.Repository.Entity.UserRole>();
            Mapper.CreateMap<VaccineManagementSystemApi.Repository.Entity.User, VaccineManagementSystemApi.DTO.User>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.User, VaccineManagementSystemApi.Repository.Entity.User>();
            Mapper.CreateMap<VaccineManagementSystemApi.Repository.Entity.Customer, VaccineManagementSystemApi.DTO.Customer>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.Customer, VaccineManagementSystemApi.Repository.Entity.Customer>();
            Mapper.CreateMap<VaccineManagementSystemApi.Repository.Entity.Hospital, VaccineManagementSystemApi.DTO.Hospital>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.Hospital, VaccineManagementSystemApi.Repository.Entity.Hospital>();
            Mapper.CreateMap<VaccineManagementSystemApi.Repository.Entity.VaccineType, VaccineManagementSystemApi.DTO.VaccineType>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.VaccineType, VaccineManagementSystemApi.Repository.Entity.VaccineType>();
            Mapper.CreateMap<VaccineManagementSystemApi.Repository.Entity.Manufacturer, VaccineManagementSystemApi.DTO.Manufacturer>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.Manufacturer, VaccineManagementSystemApi.Repository.Entity.Manufacturer>();
            Mapper.CreateMap<VaccineManagementSystemApi.Repository.Entity.Distributor, VaccineManagementSystemApi.DTO.Distributor>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.Distributor, VaccineManagementSystemApi.Repository.Entity.Distributor>();
            Mapper.CreateMap<VaccineManagementSystemApi.Repository.Entity.HospitalOrders, VaccineManagementSystemApi.DTO.HospitalOrders>();
            Mapper.CreateMap<VaccineManagementSystemApi.DTO.HospitalOrders, VaccineManagementSystemApi.Repository.Entity.HospitalOrders>();


            Mapper.CreateMap<ViewModel.UserRole, Models.UserRole>();
            Mapper.CreateMap<Models.UserRole, ViewModel.UserRole>();
            Mapper.CreateMap<ViewModel.User, Models.User>();
            Mapper.CreateMap<Models.User, ViewModel.User>();
            Mapper.CreateMap<ViewModel.Customer, Models.Customer>();
            Mapper.CreateMap<Models.Customer, ViewModel.Customer>();
            Mapper.CreateMap<ViewModel.Hospital, Models.Hospital>();
            Mapper.CreateMap<Models.Hospital, ViewModel.Hospital>();
            Mapper.CreateMap<ViewModel.VaccineType, Models.VaccineType>();
            Mapper.CreateMap<Models.VaccineType, ViewModel.VaccineType>();
            Mapper.CreateMap<ViewModel.Manufacturer, Models.Manufacturer>();
            Mapper.CreateMap<Models.Manufacturer, ViewModel.Manufacturer>();
            Mapper.CreateMap<ViewModel.Distributor, Models.Distributor>();
            Mapper.CreateMap<Models.Distributor, ViewModel.Distributor>();

            

        }
    }
}