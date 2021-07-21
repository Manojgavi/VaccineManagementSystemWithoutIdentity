namespace VaccineManagementSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHospitalOrders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HospitalOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Orders = c.Int(nullable: false),
                        HospitalId = c.Int(nullable: false),
                        VaccineTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.HospitalId, cascadeDelete: true)
                .ForeignKey("dbo.VaccineTypes", t => t.VaccineTypeId, cascadeDelete: true)
                .Index(t => t.HospitalId)
                .Index(t => t.VaccineTypeId);
            
            CreateTable(
                "dbo.HospitalVaccines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvailableVaccines = c.Int(nullable: false),
                        HospitalId = c.Int(nullable: false),
                        VaccineTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.HospitalId, cascadeDelete: true)
                .ForeignKey("dbo.VaccineTypes", t => t.VaccineTypeId, cascadeDelete: true)
                .Index(t => t.HospitalId)
                .Index(t => t.VaccineTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HospitalVaccines", "VaccineTypeId", "dbo.VaccineTypes");
            DropForeignKey("dbo.HospitalVaccines", "HospitalId", "dbo.Hospitals");
            DropForeignKey("dbo.HospitalOrders", "VaccineTypeId", "dbo.VaccineTypes");
            DropForeignKey("dbo.HospitalOrders", "HospitalId", "dbo.Hospitals");
            DropIndex("dbo.HospitalVaccines", new[] { "VaccineTypeId" });
            DropIndex("dbo.HospitalVaccines", new[] { "HospitalId" });
            DropIndex("dbo.HospitalOrders", new[] { "VaccineTypeId" });
            DropIndex("dbo.HospitalOrders", new[] { "HospitalId" });
            DropTable("dbo.HospitalVaccines");
            DropTable("dbo.HospitalOrders");
        }
    }
}
