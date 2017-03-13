using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIT280CRM.Models
{
    public class LocationModels
    {
        [Key]
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
    }
}