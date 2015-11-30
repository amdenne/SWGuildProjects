namespace CarDealership.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtestfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestInfoes", "TestField", c => c.Int(nullable: false));
            AddColumn("dbo.RequestInfoes", "RequestStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestInfoes", "TestField");
            DropColumn("dbo.RequestInfoes", "RequestStatus");

        }
    }
}
