namespace CIT280CRM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CIT280CRM.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CIT280CRM.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
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
            context.Category.AddOrUpdate(c => c.CategoryID,
                new CategoryModels { Category = "Roofing" },
                new CategoryModels { Category = "Siding" },
                new CategoryModels { Category = "Decking" },
                new CategoryModels { Category = "Windows and Doors" },
                new CategoryModels { Category = "General Merchandise" },
                new CategoryModels { Category = "Other Products" }
            );

            context.Client.AddOrUpdate(cl => cl.ClientID,
                new ClientModels { CompanyName = "Jims", Address1 = "1234 Normal Drive", City = "Detroit", State = "MI", ZipCode = "34892", Phone1 = "5551234", Email = "jims@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Toms", Address1 = "1234 Normal Avenue", City = "Chicago", State = "IL", ZipCode = "34892", Phone1 = "5551234", Email = "jims@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Johns", Address1 = "1234 Normal Street", City = "Brooklyn", State = "NY", ZipCode = "34892", Phone1 = "5551234", Email = "jims@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Joes", Address1 = "1234 Normal Road", City = "Oakland", State = "CA", ZipCode = "34892", Phone1 = "5551234", Email = "jims@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Jacks", Address1 = "1234 Normal Street", City = "Detroit", State = "MI", ZipCode = "34892", Phone1 = "5551234", Email = "jims@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Sams", Address1 = "1234 Normal Avenue", City = "Detroit", State = "MI", ZipCode = "34892", Phone1 = "5551234", Email = "jims@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Tims", Address1 = "1234 Normal Drive", City = "Detroit", State = "MI", ZipCode = "34892", Phone1 = "5551234", Email = "jims@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Janes", Address1 = "1234 Normal Road", City = "Detroit", State = "MI", ZipCode = "34892", Phone1 = "5551234", Email = "jims@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Ricks", Address1 = "1234 Normal Street", City = "Detroit", State = "MI", ZipCode = "34892", Phone1 = "5551234", Email = "jims@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Bobs", Address1 = "1234 Normal Avenue", City = "Detroit", State = "MI", ZipCode = "34892", Phone1 = "5551234", Email = "jims@gmail.com", EffDate = "4/20/2017", Active = true }
                );
        }
    }
}
