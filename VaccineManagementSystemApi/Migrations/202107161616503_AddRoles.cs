namespace VaccineManagementSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoles : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into UserRoles values('Admin')");
            Sql("Insert into UserRoles values('Manufacturer')");
            Sql("Insert into UserRoles values('Hospital')");
            Sql("Insert into UserRoles values('Distributor')");
        }
        
        public override void Down()
        {
        }
    }
}
