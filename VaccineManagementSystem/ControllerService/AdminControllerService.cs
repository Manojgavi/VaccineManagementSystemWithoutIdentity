using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.ViewModel;
using VaccineManagementSystem.Proxy;

namespace VaccineManagementSystem.ControllerService
{
    public class AdminControllerService : IAdminControllerService
    {
        private readonly IDistributorProxy distributorProxy;
        private readonly IHospitalProxy hospitalProxy;
        private readonly IManufacturerProxy manufacturerProxy;
        private readonly IUserRoleProxy userRoleProxy;
        public AdminControllerService(IUserRoleProxy userRoleProxy, IDistributorProxy distributorProxy, IHospitalProxy hospitalProxy, IManufacturerProxy manufacturerProxy)
        {
            this.userRoleProxy = userRoleProxy;
            this.distributorProxy = distributorProxy;
            this.hospitalProxy = hospitalProxy;
            this.manufacturerProxy = manufacturerProxy;
        }

        public List<Distributor> GetDistributors()
        {
            List<Distributor> distributorsView = new List<Distributor>();
            List<Models.Distributor> distributors = new List<Models.Distributor>();
            distributors = distributorProxy.GetAllDistributors();
            foreach(var distributor in distributors)
            {
                Distributor distributorView = new Distributor();
                distributorView = AutoMapper.Mapper.Map<Models.Distributor, ViewModel.Distributor>(distributor);
                distributorsView.Add(distributorView);
            }
            return distributorsView;
        }

        public List<Hospital> GetHospitals()
        {
            List<Hospital> hospitalsView = new List<Hospital>();
            List<Models.Hospital> hospitals = new List<Models.Hospital>();
            hospitals = hospitalProxy.GetAllHospitals();
            foreach (var hospital in hospitals)
            {
                Hospital hospitalView = new Hospital();
                hospitalView = AutoMapper.Mapper.Map<Models.Hospital, ViewModel.Hospital>(hospital);
                hospitalsView.Add(hospitalView);
            }
            return hospitalsView;
        }

        public List<Manufacturer> GetManufacturers()
        {
            List<Manufacturer> manufacturersView = new List<Manufacturer>();
            List<Models.Manufacturer> manufacturers = new List<Models.Manufacturer>();
            manufacturers = manufacturerProxy.GetAllManufacturers();
            foreach (var manufacturer in manufacturers)
            {
                Manufacturer manufacturerView = new Manufacturer();
                manufacturerView = AutoMapper.Mapper.Map<Models.Manufacturer, ViewModel.Manufacturer>(manufacturer);
                manufacturersView.Add(manufacturerView);
            }
            return manufacturersView;
        }
        //public RegisterViewModel Register()
        //{
        //    List<UserRole> userRoleView = new List<UserRole>();
        //    List<Models.UserRole> userRoles = new List<Models.UserRole>();
        //    ViewModel.User userView = new ViewModel.User();
        //    userRoles = userRoleProxy.GetAllUserRoles();
        //    //userView = AutoMapper.Mapper.Map<Models.User, ViewModel.User>(user);
        //    foreach (var userRole in userRoles)
        //    {
        //        userRoleView.Add(AutoMapper.Mapper.Map<Models.UserRole, ViewModel.UserRole>(userRole));
        //    }
        //    RegisterViewModel registerViewModel = new RegisterViewModel()
        //    {

        //        UserRole = userRoleView

        //    };
        //    return registerViewModel;

        //}

        public RegisterViewModel UserFromHospital(int id)
        {
            Models.Hospital hospital = new Models.Hospital();
            
            hospital=hospitalProxy.GetHospitalById(id);
            List<UserRole> userRoleView = new List<UserRole>();
            List<Models.UserRole> userRoles = new List<Models.UserRole>();
            ViewModel.User userView = new ViewModel.User();
            userRoles = userRoleProxy.GetAllUserRoles();
            
            foreach (var userRole in userRoles)
            {
                userRoleView.Add(AutoMapper.Mapper.Map<Models.UserRole, ViewModel.UserRole>(userRole));
            }

            RegisterViewModel user = new RegisterViewModel()
            {
                Email = hospital.Email,
                Password = hospital.Password,
                UserRoleId = 3,
                UserRole = userRoleView

            };
            return user;
        }

        public RegisterViewModel UserFromDistributor(int id)
        {
            Models.Distributor distributor = new Models.Distributor();

            distributor = distributorProxy.GetDistributorById(id);

            List<UserRole> userRoleView = new List<UserRole>();
            List<Models.UserRole> userRoles = new List<Models.UserRole>();
            ViewModel.User userView = new ViewModel.User();
            userRoles = userRoleProxy.GetAllUserRoles();

            foreach (var userRole in userRoles)
            {
                userRoleView.Add(AutoMapper.Mapper.Map<Models.UserRole, ViewModel.UserRole>(userRole));
            }
            RegisterViewModel user = new RegisterViewModel()
            {
                Email = distributor.Email,
                Password = distributor.Password,
                UserRoleId = 4,
                UserRole = userRoleView
            };
            return user;
        }

        public RegisterViewModel UserFromManufacturer(int id)
        {
            Models.Manufacturer manufacturer = new Models.Manufacturer();

            manufacturer = manufacturerProxy.GetManufacturerById(id);

            List<UserRole> userRoleView = new List<UserRole>();
            List<Models.UserRole> userRoles = new List<Models.UserRole>();
            ViewModel.User userView = new ViewModel.User();
            userRoles = userRoleProxy.GetAllUserRoles();

            foreach (var userRole in userRoles)
            {
                userRoleView.Add(AutoMapper.Mapper.Map<Models.UserRole, ViewModel.UserRole>(userRole));
            }
            RegisterViewModel user = new RegisterViewModel()
            {
                Email = manufacturer.Email,
                Password = manufacturer.Password,
                UserRoleId = 2,
                UserRole = userRoleView
            };
            return user;
        }
    }
}