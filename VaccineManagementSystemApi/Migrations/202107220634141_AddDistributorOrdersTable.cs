namespace VaccineManagementSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDistributorOrdersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DistributorOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Orders = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        Status = c.String(),
                        DistributorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Distributors", t => t.DistributorId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.ManufacturerId)
                .Index(t => t.DistributorId);
            
            CreateTable(
                "dbo.DistributorVaccines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvailableVaccines = c.Int(nullable: false),
                        HospitalId = c.Int(nullable: false),
                        VaccineTypeId = c.Int(nullable: false),
                        Distributor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Distributors", t => t.Distributor_Id)
                .ForeignKey("dbo.VaccineTypes", t => t.VaccineTypeId, cascadeDelete: true)
                .Index(t => t.VaccineTypeId)
                .Index(t => t.Distributor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DistributorVaccines", "VaccineTypeId", "dbo.VaccineTypes");
            DropForeignKey("dbo.DistributorVaccines", "Distributor_Id", "dbo.Distributors");
            DropForeignKey("dbo.DistributorOrders", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.DistributorOrders", "DistributorId", "dbo.Distributors");
            DropIndex("dbo.DistributorVaccines", new[] { "Distributor_Id" });
            DropIndex("dbo.DistributorVaccines", new[] { "VaccineTypeId" });
            DropIndex("dbo.DistributorOrders", new[] { "DistributorId" });
            DropIndex("dbo.DistributorOrders", new[] { "ManufacturerId" });
            DropTable("dbo.DistributorVaccines");
            DropTable("dbo.DistributorOrders");
        }
    }
}
