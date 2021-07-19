namespace VaccineManagementSystemApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roles2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "UserRole_Id", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRole_Id" });
            RenameColumn(table: "dbo.Users", name: "UserRole_Id", newName: "UserRoleId");
            AlterColumn("dbo.Users", "UserRoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "UserRoleId");
            AddForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles", "Id", cascadeDelete: true);
            DropColumn("dbo.Users", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Role", c => c.String());
            DropForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRoleId" });
            AlterColumn("dbo.Users", "UserRoleId", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "UserRoleId", newName: "UserRole_Id");
            CreateIndex("dbo.Users", "UserRole_Id");
            AddForeignKey("dbo.Users", "UserRole_Id", "dbo.UserRoles", "Id");
        }
    }
}
