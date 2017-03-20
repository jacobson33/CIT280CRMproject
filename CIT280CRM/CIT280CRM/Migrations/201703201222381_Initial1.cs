namespace CIT280CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LocationModels", newName: "Location");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Location", newName: "LocationModels");
        }
    }
}
