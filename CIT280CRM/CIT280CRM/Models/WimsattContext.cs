using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace CIT280CRM.Models
{
    public class CRMDb : DbContext
    {
        public CRMDb() : base("CRMDb")
        {

        }

        public DbSet<ClientModels> Clients { get; set; }
        public DbSet<InvoiceModels> Invoices { get; set; }
        public DbSet<SaleItemModels> SaleItems { get; set; }
        public DbSet<ProductModels> Products { get; set; }
        public DbSet<LocationModels> Locations { get; set; }
    }
}