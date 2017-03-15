using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIT280CRM.Models
{
    [Table("SaleItems")]
    public class SaleItemModels
    {
        [Key]
        public int SaleItemID { get; set; }

        public int ProductID { get; set; }

        public int InvoiceID { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}