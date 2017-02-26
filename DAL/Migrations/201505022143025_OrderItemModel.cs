namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItemModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "Product_id", "dbo.Products");
            DropIndex("dbo.OrderItems", new[] { "Product_id" });
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            RenameColumn(table: "dbo.OrderItems", name: "Order_Id", newName: "OrderId");
            RenameColumn(table: "dbo.OrderItems", name: "Product_id", newName: "ProductId");
            AlterColumn("dbo.OrderItems", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderItems", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "OrderId");
            CreateIndex("dbo.OrderItems", "ProductId");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "ProductId", "dbo.Products", "id", cascadeDelete: true);
            DropColumn("dbo.OrderItems", "OrederId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "OrederId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            AlterColumn("dbo.OrderItems", "OrderId", c => c.Int());
            AlterColumn("dbo.OrderItems", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.OrderItems", name: "ProductId", newName: "Product_id");
            RenameColumn(table: "dbo.OrderItems", name: "OrderId", newName: "Order_Id");
            CreateIndex("dbo.OrderItems", "Order_Id");
            CreateIndex("dbo.OrderItems", "Product_id");
            AddForeignKey("dbo.OrderItems", "Product_id", "dbo.Products", "id");
            AddForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
