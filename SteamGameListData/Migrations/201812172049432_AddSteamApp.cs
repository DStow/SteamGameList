namespace SteamGameListData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSteamApp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SteamApps",
                c => new
                    {
                        SteamAppId = c.Int(nullable: false, identity: true),
                        AppId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SteamAppId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SteamApps");
        }
    }
}
