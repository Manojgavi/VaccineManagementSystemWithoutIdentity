namespace VaccineManagementSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHospitalOrdersanddistributor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalOrders", "DistributorId", c => c.Int(nullable: false));
            CreateIndex("dbo.HospitalOrders", "DistributorId");
            AddForeignKey("dbo.HospitalOrders", "DistributorId", "dbo.Distributors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HospitalOrders", "DistributorId", "dbo.Distributors");
            DropIndex("dbo.HospitalOrders", new[] { "DistributorId" });
            DropColumn("dbo.HospitalOrders", "DistributorId");
        }
    }
}
