namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ourPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ourPrice");
        }
    }
}
