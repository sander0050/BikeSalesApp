namespace BikeSalesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrderItemFKToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "ProductId");
            AddForeignKey("dbo.OrderItems", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropColumn("dbo.OrderItems", "ProductId");
        }
    }
}
