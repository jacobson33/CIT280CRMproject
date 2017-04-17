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
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CIT280CRM.Models.ApplicationDbContext context)
        {
            context.Category.AddOrUpdate(c => c.CategoryID,
                new CategoryModels { Category = "Roofing" },
                new CategoryModels { Category = "Siding" },
                new CategoryModels { Category = "Decking" },
                new CategoryModels { Category = "Windows and Doors" },
                new CategoryModels { Category = "General Merchandise" },
                new CategoryModels { Category = "Other Products" }
            );

            context.Client.AddOrUpdate(cl => cl.ClientID,
                new ClientModels { CompanyName = "Jims Construction", Address1 = "1234 Normal Drive", City = "Detroit", State = "MI", ZipCode = "34892", Phone1 = "5551234", Email = "jims@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Toms Building Company", Address1 = "1235 Normal Avenue", City = "Chicago", State = "IL", ZipCode = "54678", Phone1 = "5551235", Email = "Toms@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Houses R Us", Address1 = "1236 Normal Street", City = "Brooklyn", State = "NY", ZipCode = "12486", Phone1 = "5551236", Email = "Johns@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Joes Siding and Roofing", Address1 = "1237 Normal Road", City = "Oakland", State = "CA", ZipCode = "87230", Phone1 = "5551237", Email = "Joes@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Cedar Building Company ", Address1 = "1238 Normal Street", City = "Denver", State = "CO", ZipCode = "32468", Phone1 = "5551238", Email = "Jacks@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Traverse Construction Company", Address1 = "1239 Normal Avenue", City = "Portland", State = "OR", ZipCode = "32690", Phone1 = "5551239", Email = "Sams@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Tims Tall Towers", Address1 = "2234 Normal Drive", City = "Boston", State = "MA", ZipCode = "05623", Phone1 = "5552234", Email = "Tims@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Janes Contracting", Address1 = "2235 Normal Road", City = "Miami", State = "FL", ZipCode = "34512", Phone1 = "5552235", Email = "Janes@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Ricks Roofing", Address1 = "2236 Normal Street", City = "Dallas", State = "TX", ZipCode = "65378", Phone1 = "5552236", Email = "Ricks@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Bobs Brick Building", Address1 = "2237 Normal Avenue", City = "Seattle", State = "WA", ZipCode = "45369", Phone1 = "5552237", Email = "Bobs@gmail.com", EffDate = "4/20/2017", Active = true }
                );

            context.Products.AddOrUpdate(p => p.ProductID,
                new ProductModels { Name = "Engineered Wood", Price = 20, CategoryID = 3 },
                new ProductModels { Name = "Window", Price = 30, CategoryID = 4 },
                new ProductModels { Name = "Lumber", Price = 40, CategoryID = 5 },
                new ProductModels { Name = "Specialty Lumber", Price = 50, CategoryID = 5 },
                new ProductModels { Name = "Railing", Price = 20, CategoryID = 5 },
                new ProductModels { Name = "Insulation", Price = 5, CategoryID = 5 },
                new ProductModels { Name = "Door", Price = 40, CategoryID = 4 },
                new ProductModels { Name = "Shingle", Price = 20, CategoryID = 1 },
                new ProductModels { Name = "PVC", Price = 10, CategoryID = 1 },
                new ProductModels { Name = "Siding", Price = 25, CategoryID = 2 }
                );

            context.Location.AddOrUpdate(l => l.LocationID,
                new LocationModels { Name = "Grand Rapids", StreetAddress = "1456 28th Street", City = "Wyoming", State = "MI", Zip = 49509 },
                new LocationModels { Name = "Lansing", StreetAddress = "1615 East Miller Road", City = "Lansing", State = "MI", Zip = 48911 },
                new LocationModels { Name = "Saginaw", StreetAddress = "3460 Bay Road", City = "Saginaw", State = "MI", Zip = 48603 },
                new LocationModels { Name = "Sterling Heights", StreetAddress = "33663 Mound Road", City = "Sterling Heights", State = "MI", Zip = 48310 },
                new LocationModels { Name = "Toledo", StreetAddress = "26440 Southpoint Road", City = "Perrysburg", State = "OH", Zip = 43551 },
                new LocationModels { Name = "Traverse City", StreetAddress = "7201 East M-72", City = "Williamsburg", State = "MI", Zip = 49690 },
                new LocationModels { Name = "Waterford", StreetAddress = "1131 Sylvertis", City = "Waterford", State = "MI", Zip = 48328 },
                new LocationModels { Name = "Wayne", StreetAddress = "36340 Van Born Road", City = "Wayne", State = "MI", Zip = 48184 }
                );
        }
    }
}
