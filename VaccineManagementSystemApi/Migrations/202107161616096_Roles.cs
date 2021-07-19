namespace VaccineManagementSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            AddColumn("dbo.Users", "UserRole_Id", c => c.Int());
            CreateIndex("dbo.Users", "UserRole_Id");
            AddForeignKey("dbo.Users", "UserRole_Id", "dbo.UserRoles", "Id");
            DropColumn("dbo.UserRoles", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserRoles", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "UserRole_Id", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRole_Id" });
            DropColumn("dbo.Users", "UserRole_Id");
            CreateIndex("dbo.UserRoles", "UserId");
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
