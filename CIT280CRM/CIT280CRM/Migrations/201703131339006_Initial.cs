namespace CIT280CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientModels",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 200),
                        Address1 = c.String(maxLength: 200),
                        Address2 = c.String(maxLength: 200),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 5),
                        ZipCode = c.String(maxLength: 20),
                        Phone1 = c.String(nullable: false, maxLength: 50),
                        Phone1Type = c.Int(nullable: false),
                        Phone2 = c.String(maxLength: 50),
                        Phone2Type = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        EffDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DeleteInd = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.InvoiceModels",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        TotalAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID);
            
            CreateTable(
                "dbo.SaleItemModels",
                c => new
                    {
                        SaleItemID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        InvoiceID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SaleItemID)
                .ForeignKey("dbo.InvoiceModels", t => t.InvoiceID, cascadeDelete: true)
                .Index(t => t.InvoiceID);
            
            CreateTable(
                "dbo.LocationModels",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.ProductModels",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleItemModels", "InvoiceID", "dbo.InvoiceModels");
            DropIndex("dbo.SaleItemModels", new[] { "InvoiceID" });
            DropTable("dbo.ProductModels");
            DropTable("dbo.LocationModels");
            DropTable("dbo.SaleItemModels");
            DropTable("dbo.InvoiceModels");
            DropTable("dbo.ClientModels");
        }
    }
}
