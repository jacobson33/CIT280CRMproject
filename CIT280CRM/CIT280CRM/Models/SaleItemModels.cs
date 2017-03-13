using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIT280CRM.Models
{
    public class SaleItemModels
    {
        [Key]
        public int SaleItemID { get; set; }

        public int ProductID { get; set; }

        public int InvoiceID { get; set; }

        public int Amount { get; set; }
    }
}