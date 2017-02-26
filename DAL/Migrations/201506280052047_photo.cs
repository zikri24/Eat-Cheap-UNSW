namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Businesses", "photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Businesses", "photo");
        }
    }
}
