namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewBusiness : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Businesses", "Shop", c => c.String());
            AlterColumn("dbo.Businesses", "city", c => c.Int(nullable: false));
            AlterColumn("dbo.Businesses", "foodCourt", c => c.Int(nullable: false));
            DropColumn("dbo.Businesses", "owner");
            DropColumn("dbo.Businesses", "state");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Businesses", "state", c => c.Int(nullable: false));
            AddColumn("dbo.Businesses", "owner", c => c.String());
            AlterColumn("dbo.Businesses", "foodCourt", c => c.String());
            AlterColumn("dbo.Businesses", "city", c => c.String());
            DropColumn("dbo.Businesses", "Shop");
        }
    }
}
