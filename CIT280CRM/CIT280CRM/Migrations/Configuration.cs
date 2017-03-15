namespace CIT280CRM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CIT280CRM.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CIT280CRM.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Client.AddOrUpdate(c => c.ClientID,
                new Models.ClientModels { CompanyName = "Company 1",
                    Address1 = "",
                    City = "",
                    State = "",
                    ZipCode = "12345",
                    Phone1 = "",
                    Phone1Type = 0,
                    Phone2 = "",
                    Phone2Type = 1,
                    Active = true,
                    DeleteInd = false
                },
                new Models.ClientModels
                {
                    CompanyName = "Company 2",
                    Address1 = "",
                    City = "",
                    State = "",
                    ZipCode = "12345",
                    Phone1 = "",
                    Phone1Type = 0,
                    Phone2 = "",
                    Phone2Type = 1,
                    Active = true,
                    DeleteInd = false
                },
                new Models.ClientModels
                {
                    CompanyName = "Company 3",
                    Address1 = "",
                    City = "",
                    State = "",
                    ZipCode = "12345",
                    Phone1 = "",
                    Phone1Type = 0,
                    Phone2 = "",
                    Phone2Type = 1,
                    Active = true,
                    DeleteInd = false
                }
            );
        }
    }
}
