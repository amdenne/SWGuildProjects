namespace CapstoneBlog.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readdedValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String());
            AlterColumn("dbo.Posts", "Content", c => c.String());
        }
    }
}
