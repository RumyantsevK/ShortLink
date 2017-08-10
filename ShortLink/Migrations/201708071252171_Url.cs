namespace ShortLink.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Url : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Urls",
                c => new
                    {
                        ShortUrl = c.String(nullable: false, maxLength: 128),
                        LongUrl = c.String(),
                    })
                .PrimaryKey(t => t.ShortUrl);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Urls");
        }
    }
}
