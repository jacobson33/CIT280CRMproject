﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIT280CRM.Models
{
    [Table("Category")]
    public class CategoryModels
    {
        [Key]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        [Display(Name = "Name")]
        public string Category { get; set; }
    }
}