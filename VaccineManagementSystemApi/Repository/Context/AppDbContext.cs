using System;
using System.Data.Entity;
using System.Linq;
using VaccineManagementSystemApi.Repository.Entity;

namespace VaccineManagementSystemApi.Repository.Context
{
    public class AppDbContext : DbContext
    {
        // Your context has been configured to use a 'AppDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'VaccineManagementSystemApi.Repository.Context.AppDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AppDbContext' 
        // connection string in the application configuration file.
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Distributor> Distributors { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<VaccineType> VaccineTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<HospitalOrders> HospitalOrders { get; set; }
        public virtual DbSet<HospitalVaccines> HospitalVaccines { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}