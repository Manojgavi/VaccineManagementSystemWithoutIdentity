using System;

using Unity;
using VaccineManagementSystemApi.Services;
using VaccineManagementSystem.Proxy;
using VaccineManagementSystemApi.Repository;
using VaccineManagementSystem.ControllerService;

namespace VaccineManagementSystem
{
    
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

       
        public static void RegisterTypes(IUnityContainer container)
        {
            
            container.RegisterType<IUserQueryService, UserQueryService>();
            container.RegisterType<IUserCommandService, UserCommandService>();
            container.RegisterType<IUserProxy, UserProxy>();
            container.RegisterType<IUserRepository, UserRepository>();

            container.RegisterType<IUserRoleQueryService, UserRoleQueryService>();
            container.RegisterType<IUserRoleCommandService, UserRoleCommandService>();
            container.RegisterType<IUserRoleProxy, UserRoleProxy>();
            container.RegisterType<IUserRoleRepository, UserRoleRepository>();

            container.RegisterType<IAccountControllerService, AccountControllerService>();
            container.RegisterType<IVaccineTypeControllerService, VaccineTypeControllerService>();
            container.RegisterType<IManufacturerControllerService, ManufacturerControllerService>();
            container.RegisterType<IHospitalControllerService, HospitalControllerService>();
            container.RegisterType<IDistributorControllerService, DistributorControllerService>();
            container.RegisterType<ICustomerControllerService, CustomerControllerService>();
            container.RegisterType<IAdminControllerService, AdminControllerService>();


            container.RegisterType<ICustomerQueryService, CustomerQueryService>();
            container.RegisterType<ICustomerCommandService, CustomerCommandService>();
            container.RegisterType<ICustomerProxy, CustomerProxy>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();

            container.RegisterType<IHospitalQueryService, HospitalQueryService>();
            container.RegisterType<IHospitalCommandService, HospitalCommandService>();
            container.RegisterType<IHospitalProxy, HospitalProxy>();
            container.RegisterType<IHospitalRepository, HospitalRepository>();

            container.RegisterType<IDistributorQueryService, DistributorQueryService>();
            container.RegisterType<IDistributorCommandService, DistributorCommandService>();
            container.RegisterType<IDistributorProxy, DistributorProxy>();
            container.RegisterType<IDistributorRepository, DistributorRepository>();

            container.RegisterType<IManufacturerQueryService, ManufacturerQueryService>();
            container.RegisterType<IManufacturerCommandService, ManufacturerCommandService>();
            container.RegisterType<IManufacturerProxy, ManufacturerProxy>();
            container.RegisterType<IManufacturerRepository, ManufacturerRepository>();

            container.RegisterType<IVaccineTypeQueryService, VaccineTypeQueryService>();
            container.RegisterType<IVaccineTypeCommandService, VaccineTypeCommandService>();
            container.RegisterType<IVaccineTypeProxy, VaccineTypeProxy>();
            container.RegisterType<IVaccineTypeRepository, VaccineTypeRepository>();
        }
    }
}