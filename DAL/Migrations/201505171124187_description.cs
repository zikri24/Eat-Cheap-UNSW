namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class description : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "description", c => c.String(nullable: false));
        }
    }
}
