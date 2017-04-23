using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIT280CRM.Models
{
    public enum Status
    {
        Created = 0, Processing, Shipped, Complete, Holding, Cancelled 
    }

    [Table("Invoice")]
    public class InvoiceModels
    {
        [Key]
        public int InvoiceID { get; set; }

        [Display(Name = "Client")]
        public int ClientID { get; set; }

        [ForeignKey("ClientID")]
        public ClientModels ClientModels { get; set; }

        [Display(Name = "Total")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "P/O #")]
        public string PurchaseOrder { get; set; }

        [Display(Name = "Date")]
        public string InvoiceDate { get; set; }

        [Display(Name = "Ship Date")]
        public string ShipDate { get; set; }

        [Display(Name = "Status")]
        public Status InvoiceStatus { get; set; }

        public List<SaleItemModels> LineItems { get; set; }

        public InvoiceModels()
        {
            this.LineItems = new List<SaleItemModels>();
        }
        
    }
}