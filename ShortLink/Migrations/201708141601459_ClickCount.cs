namespace ShortLink.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClickCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Urls", "ClickCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Urls", "ClickCount");
        }
    }
}
