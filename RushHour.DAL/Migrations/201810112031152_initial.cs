namespace RushHour.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Address1 = c.String(maxLength: 255),
                        Address2 = c.String(maxLength: 255),
                        City = c.String(maxLength: 100),
                        State = c.String(maxLength: 2),
                        Zip = c.String(maxLength: 9),
                        CustomerId = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Address1 = c.String(maxLength: 255),
                        Address2 = c.String(maxLength: 255),
                        City = c.String(maxLength: 100),
                        State = c.String(maxLength: 2),
                        Zip = c.String(maxLength: 9),
                        EmailAddress = c.String(maxLength: 150),
                        PointOfContact = c.String(maxLength: 100),
                        PrimaryPhone = c.String(maxLength: 10),
                        SecondaryPhone = c.String(maxLength: 10),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerRefNo = c.String(maxLength: 30),
                        RefNo = c.Int(nullable: false),
                        DeliveryCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WeightCharge = c.Decimal(precision: 18, scale: 2),
                        ReturnCharge = c.Decimal(precision: 18, scale: 2),
                        WaitingTimeCharge = c.Decimal(precision: 18, scale: 2),
                        CodCharge = c.Decimal(precision: 18, scale: 2),
                        TotalCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ArrivalTime = c.DateTime(),
                        DepartureTime = c.DateTime(),
                        DeliveryDateTime = c.DateTime(),
                        IsPrepaid = c.Boolean(),
                        IsReg = c.Boolean(),
                        IsRush = c.Boolean(),
                        IsCod = c.Boolean(),
                        ReceivedBy = c.String(maxLength: 150),
                        CustomerId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        DeliverToAddressId = c.Int(nullable: false),
                        PickupAddressId = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerAddresses", t => t.DeliverToAddressId)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.CustomerAddresses", t => t.PickupAddressId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.DriverId)
                .Index(t => t.DeliverToAddressId)
                .Index(t => t.PickupAddressId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Address1 = c.String(maxLength: 255),
                        Address2 = c.String(maxLength: 255),
                        City = c.String(maxLength: 100),
                        State = c.String(maxLength: 2),
                        Zip = c.String(maxLength: 9),
                        HomePhone = c.String(maxLength: 10),
                        MobilePhone = c.String(maxLength: 50),
                        EmailAddress = c.String(maxLength: 150),
                        Social = c.String(maxLength: 9),
                        DateOfBirth = c.DateTime(),
                        DateHired = c.DateTime(),
                        HourlyRate = c.Decimal(precision: 18, scale: 2),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Freights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Description = c.String(maxLength: 255),
                        Weight = c.String(maxLength: 25),
                        DeliveryId = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deliveries", t => t.DeliveryId, cascadeDelete: true)
                .Index(t => t.DeliveryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deliveries", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Deliveries", "PickupAddressId", "dbo.CustomerAddresses");
            DropForeignKey("dbo.Freights", "DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.Deliveries", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Deliveries", "DeliverToAddressId", "dbo.CustomerAddresses");
            DropForeignKey("dbo.CustomerAddresses", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Freights", new[] { "DeliveryId" });
            DropIndex("dbo.Deliveries", new[] { "PickupAddressId" });
            DropIndex("dbo.Deliveries", new[] { "DeliverToAddressId" });
            DropIndex("dbo.Deliveries", new[] { "DriverId" });
            DropIndex("dbo.Deliveries", new[] { "CustomerId" });
            DropIndex("dbo.CustomerAddresses", new[] { "CustomerId" });
            DropTable("dbo.Freights");
            DropTable("dbo.Drivers");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerAddresses");
        }
    }
}
