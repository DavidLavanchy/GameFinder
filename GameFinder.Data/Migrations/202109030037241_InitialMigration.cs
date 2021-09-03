namespace GameFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameSystem", "SystemTitle", c => c.String(nullable: false));
            AddColumn("dbo.Genre", "GenreType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Genre", "GenreType");
            DropColumn("dbo.GameSystem", "SystemTitle");
        }
    }
}
