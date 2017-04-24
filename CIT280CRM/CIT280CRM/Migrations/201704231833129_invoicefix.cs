namespace CIT280CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoicefix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaleItems", "ProductID", "dbo.Products");
            DropIndex("dbo.SaleItems", new[] { "ProductID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.SaleItems", "ProductID");
            AddForeignKey("dbo.SaleItems", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
        }
    }
}
