namespace CIT280CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Category");
        }
    }
}
