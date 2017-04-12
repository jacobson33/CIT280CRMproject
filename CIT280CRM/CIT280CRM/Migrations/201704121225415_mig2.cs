namespace CIT280CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Category");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Category");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Category", "CategoryID", cascadeDelete: true);
        }
    }
}
