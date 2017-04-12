using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIT280CRM.Models.ViewModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public string Category { get; set; }
    }
}