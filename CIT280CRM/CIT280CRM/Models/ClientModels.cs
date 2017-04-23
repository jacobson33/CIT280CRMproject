using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CIT280CRM.Models
{
    public enum PhoneType
    {
        Work = 1, Cell = 2, Home = 3, Other = 4
    }


    [Table("Client")]
    public class ClientModels
    {
        [Key]
        public int ClientID { get; set; }

        [Display(Name = "Company Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Company Name is Required Field.")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "Company Name Length Between 4 to 200 character")]
        public string CompanyName { get; set; }

        [Display(Name = "Address Line 1")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "Address Length Between 4 to 200 character")]
        public string Address1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(200)]
        public string Address2 { get; set; }

        [StringLength(50, MinimumLength = 4, ErrorMessage = "City Length Between 4 to 200 character")]
        public string City { get; set; }

        [StringLength(5)]
        public string State { get; set; }

        [Display(Name = "Zip")]
        [StringLength(20)]
        public string ZipCode { get; set; }

        [Display(Name = "Primary Phone")]
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number is Required Field.")]
        public string Phone1 { get; set; }

        [Display(Name = "Primary Type")]
        public PhoneType Phone1Type { get; set; }

        [Display(Name = "Secondary Phone")]
        [StringLength(50)]
        public string Phone2 { get; set; }

        [Display(Name = "Secondary Type")]
        public PhoneType Phone2Type { get; set; }

        [Required]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Email Address is not Valid.")]
        public string Email { get; set; }

        public string EffDate { get; set; }

        public bool Active { get; set; }

        public bool DeleteInd { get; set; }

        [NotMapped]
        public System.Web.Mvc.SelectList ClientList { get; set; }

    }
}