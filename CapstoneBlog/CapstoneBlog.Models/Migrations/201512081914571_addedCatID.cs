namespace CapstoneBlog.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCatID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "CatID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "CatID");
        }
    }
}
