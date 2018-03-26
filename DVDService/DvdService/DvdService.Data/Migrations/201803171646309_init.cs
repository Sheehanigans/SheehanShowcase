namespace DvdService.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        ReleaseYear = c.Int(nullable: false),
                        Director = c.String(maxLength: 50),
                        Rating = c.String(maxLength: 50),
                        Notes = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.DvdId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dvds");
        }
    }
}
