namespace VaccineManagementSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusForHospitalOrders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalOrders", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HospitalOrders", "Status");
        }
    }
}
