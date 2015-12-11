namespace CapstoneBlog.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedWebpages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Webpages",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 30),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Title);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Webpages");
        }
    }
}
