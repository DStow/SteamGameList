namespace SteamGameListData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReleaseDateToSteamApp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SteamApps", "ReleaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SteamApps", "ReleaseDate");
        }
    }
}
