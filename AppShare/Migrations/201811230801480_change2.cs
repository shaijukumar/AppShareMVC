namespace AppShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiteContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleURL = c.String(),
                        MainTopicId = c.Int(nullable: false),
                        Title = c.String(),
                        StatusId = c.Int(nullable: false),
                        DocumentHTML = c.String(),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SiteContentStatus", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.ContentTopics", t => t.Topic_Id)
                .Index(t => t.StatusId)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.SiteContentStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SiteContents", "Topic_Id", "dbo.ContentTopics");
            DropForeignKey("dbo.SiteContents", "StatusId", "dbo.SiteContentStatus");
            DropIndex("dbo.SiteContents", new[] { "Topic_Id" });
            DropIndex("dbo.SiteContents", new[] { "StatusId" });
            DropTable("dbo.SiteContentStatus");
            DropTable("dbo.SiteContents");
        }
    }
}
