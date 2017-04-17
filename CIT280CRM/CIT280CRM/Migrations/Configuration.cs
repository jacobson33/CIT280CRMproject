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
                new ClientModels { CompanyName = "Toms", Address1 = "1235 Normal Avenue", City = "Chicago", State = "IL", ZipCode = "54678", Phone1 = "5551235", Email = "Toms@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Johns", Address1 = "1236 Normal Street", City = "Brooklyn", State = "NY", ZipCode = "12486", Phone1 = "5551236", Email = "Johns@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Joes", Address1 = "1237 Normal Road", City = "Oakland", State = "CA", ZipCode = "87230", Phone1 = "5551237", Email = "Joes@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Jacks", Address1 = "1238 Normal Street", City = "Denver", State = "CO", ZipCode = "32468", Phone1 = "5551238", Email = "Jacks@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Sams", Address1 = "1239 Normal Avenue", City = "Portland", State = "OR", ZipCode = "32690", Phone1 = "5551239", Email = "Sams@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Tims", Address1 = "2234 Normal Drive", City = "Boston", State = "MA", ZipCode = "05623", Phone1 = "5552234", Email = "Tims@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Janes", Address1 = "2235 Normal Road", City = "Miami", State = "FL", ZipCode = "34512", Phone1 = "5552235", Email = "Janes@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Ricks", Address1 = "2236 Normal Street", City = "Dallas", State = "TX", ZipCode = "65378", Phone1 = "5552236", Email = "Ricks@gmail.com", EffDate = "4/20/2017", Active = true },
                new ClientModels { CompanyName = "Bobs", Address1 = "2237 Normal Avenue", City = "Seattle", State = "WA", ZipCode = "45369", Phone1 = "5552237", Email = "Bobs@gmail.com", EffDate = "4/20/2017", Active = true }
                );

            context.Products.AddOrUpdate(p => p.ProductID,
                new ProductModels { Name = "Wood", Price = 20, CategoryID = 3 },
                new ProductModels { Name = "Window", Price = 30, CategoryID = 4 },
                new ProductModels { Name = "Drill", Price = 40, CategoryID = 5 },
                new ProductModels { Name = "Nail", Price = 5, CategoryID = 5 },
                new ProductModels { Name = "Ladder", Price = 20, CategoryID = 5 },
                new ProductModels { Name = "Screw", Price = 5, CategoryID = 5 },
                new ProductModels { Name = "Hammer", Price = 10, CategoryID = 5 },
                new ProductModels { Name = "Shingle", Price = 20, CategoryID = 1 },
                new ProductModels { Name = "Vent", Price = 20, CategoryID = 1 },
                new ProductModels { Name = "Siding", Price = 25, CategoryID = 2 }
                );

            context.Location.AddOrUpdate(l => l.LocationID,
                new LocationModels { Name = "", StreetAddress = "5238 Normal Street", City = "Denver", State = "CO", Zip = 32468 },
                new LocationModels { Name = "", StreetAddress = "7239 Normal Avenue", City = "Portland", State = "OR", Zip = 32690 },
                new LocationModels { Name = "", StreetAddress = "4237 Normal Avenue", City = "Seattle", State = "WA", Zip = 45369 },
                new LocationModels { Name = "", StreetAddress = "5234 Normal Drive", City = "Boston", State = "MA", Zip = 05623 },
                new LocationModels { Name = "", StreetAddress = "5236 Normal Street", City = "Brooklyn", State = "NY", Zip = 12486 },
                new LocationModels { Name = "", StreetAddress = "6235 Normal Avenue", City = "Chicago", State = "IL", Zip = 54678 },
                new LocationModels { Name = "", StreetAddress = "3234 Normal Drive", City = "Detroit", State = "MI", Zip = 34892 },
                new LocationModels { Name = "", StreetAddress = "8235 Normal Road", City = "Miami", State = "FL", Zip = 34512 },
                new LocationModels { Name = "", StreetAddress = "9236 Normal Street", City = "Dallas", State = "TX", Zip = 65378 },
                new LocationModels { Name = "", StreetAddress = "0237 Normal Road", City = "Oakland", State = "CA", Zip = 87230 }
                );

            context.SaleItem.AddOrUpdate(s => s.SaleItemID,
                new SaleItemModels { InvoiceID = 1, Quantity = 8, Price = 10 },
                new SaleItemModels { InvoiceID = 2, Quantity = 15, Price = 20 },
                new SaleItemModels { InvoiceID = 3, Quantity = 32, Price = 35 },
                new SaleItemModels { InvoiceID = 4, Quantity = 24, Price = 40 },
                new SaleItemModels { InvoiceID = 5, Quantity = 22, Price = 50 },
                new SaleItemModels { InvoiceID = 6, Quantity = 36, Price = 60 },
                new SaleItemModels { InvoiceID = 7, Quantity = 41, Price = 55 },
                new SaleItemModels { InvoiceID = 8, Quantity = 23, Price = 70 },
                new SaleItemModels { InvoiceID = 9, Quantity = 38, Price = 80 },
                new SaleItemModels { InvoiceID = 10, Quantity = 10, Price = 25 }
                );
        }
    }
}
