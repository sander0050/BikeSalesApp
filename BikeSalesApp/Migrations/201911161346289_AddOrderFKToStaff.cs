namespace BikeSalesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderFKToStaff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "StaffId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "StaffId");
            AddForeignKey("dbo.Orders", "StaffId", "dbo.Staffs", "StaffId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "StaffId", "dbo.Staffs");
            DropIndex("dbo.Orders", new[] { "StaffId" });
            DropColumn("dbo.Orders", "StaffId");
        }
    }
}
