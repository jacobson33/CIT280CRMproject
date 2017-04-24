using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIT280CRM.Models
{
    [Table("Products")]
    public class ProductModels
    {
        [Key]
        [Display(Name = "Product")]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
    }
}