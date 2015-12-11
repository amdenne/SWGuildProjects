namespace CapstoneBlog.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CatID = c.Int(nullable: false, identity: true),
                        category = c.String(),
                    })
                .PrimaryKey(t => t.CatID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Title = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PostID);
            
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        Post_PostID = c.Int(nullable: false),
                        Category_CatID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_PostID, t.Category_CatID })
                .ForeignKey("dbo.Posts", t => t.Post_PostID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_CatID, cascadeDelete: true)
                .Index(t => t.Post_PostID)
                .Index(t => t.Category_CatID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostCategories", "Category_CatID", "dbo.Categories");
            DropForeignKey("dbo.PostCategories", "Post_PostID", "dbo.Posts");
            DropIndex("dbo.PostCategories", new[] { "Category_CatID" });
            DropIndex("dbo.PostCategories", new[] { "Post_PostID" });
            DropTable("dbo.PostCategories");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
