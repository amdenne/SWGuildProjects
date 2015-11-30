namespace CarDealership.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInitialTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestInfoes",
                c => new
                    {
                        RequestInfoID = c.Int(nullable: false, identity: true),
                        VehicleID = c.Int(nullable: false),
                        Name = c.String(),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                        BestTimeToCall = c.DateTime(nullable: false),
                        PreferredContactMethod = c.String(),
                        TimeframeToPurchase = c.DateTime(nullable: false),
                        AdditionalInformation = c.String(),
                        LastContactDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequestInfoID)
                .ForeignKey("dbo.Vehicles", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        AdTitle = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PictureURL = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestInfoes", "VehicleID", "dbo.Vehicles");
            DropIndex("dbo.RequestInfoes", new[] { "VehicleID" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.RequestInfoes");
        }
    }
}
