namespace CarDealership.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedEnumToInt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RequestInfoes", "TestField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequestInfoes", "TestField", c => c.Int(nullable: false));
        }
    }
}
