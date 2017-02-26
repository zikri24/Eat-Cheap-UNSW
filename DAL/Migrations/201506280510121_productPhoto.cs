namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "photo");
        }
    }
}
