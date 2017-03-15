using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIT280CRM.Models
{
    public class InvoiceModels
    {
        [Key]
        public int InvoiceID { get; set; }

        public int ClientID { get; set; }

        public decimal TotalAmount { get; set; }

        public List<SaleItemModels> LineItems { get; set; }
        
    }
}