using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIT280CRM.Models
{
    [Table("Invoice")]
    public class InvoiceModels
    {
        [Key]
        public int InvoiceID { get; set; }

        public int ClientID { get; set; }

        [ForeignKey("ClientID")]
        public ClientModels ClientModels { get; set; }

        public decimal TotalAmount { get; set; }

        public string PurchaseOrder { get; set; }

        public string InvoiceDate { get; set; }

        public string ShipDate { get; set; }

        public string InvoiceStatus { get; set; }

        public List<SaleItemModels> LineItems { get; set; }

        public InvoiceModels()
        {
            this.LineItems = new List<SaleItemModels>();
        }
        
    }
}