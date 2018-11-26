namespace AppShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SiteContents", "Topic_Id", "dbo.ContentTopics");
            DropIndex("dbo.SiteContents", new[] { "Topic_Id" });
            RenameColumn(table: "dbo.SiteContents", name: "Topic_Id", newName: "TopicId");
            AlterColumn("dbo.SiteContents", "TopicId", c => c.Int(nullable: false));
            CreateIndex("dbo.SiteContents", "TopicId");
            AddForeignKey("dbo.SiteContents", "TopicId", "dbo.ContentTopics", "Id", cascadeDelete: true);
            DropColumn("dbo.SiteContents", "MainTopicId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SiteContents", "MainTopicId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SiteContents", "TopicId", "dbo.ContentTopics");
            DropIndex("dbo.SiteContents", new[] { "TopicId" });
            AlterColumn("dbo.SiteContents", "TopicId", c => c.Int());
            RenameColumn(table: "dbo.SiteContents", name: "TopicId", newName: "Topic_Id");
            CreateIndex("dbo.SiteContents", "Topic_Id");
            AddForeignKey("dbo.SiteContents", "Topic_Id", "dbo.ContentTopics", "Id");
        }
    }
}
