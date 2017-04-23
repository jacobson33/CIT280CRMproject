namespace CIT280CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update423 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoice", "InvoiceStatus", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoice", "InvoiceStatus", c => c.String());
        }
    }
}
