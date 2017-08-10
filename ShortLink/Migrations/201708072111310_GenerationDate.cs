namespace ShortLink.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenerationDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Urls", "GenerationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Urls", "GenerationDate");
        }
    }
}
