namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropdown : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Businesses", "name", c => c.String(nullable: false));
            AlterColumn("dbo.BusinessReviews", "Review", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "description", c => c.String(nullable: false));
            AlterColumn("dbo.ProductReviews", "Review", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductReviews", "Review", c => c.String());
            AlterColumn("dbo.Products", "description", c => c.String());
            AlterColumn("dbo.Products", "name", c => c.String());
            AlterColumn("dbo.BusinessReviews", "Review", c => c.String());
            AlterColumn("dbo.Businesses", "name", c => c.String());
        }
    }
}
