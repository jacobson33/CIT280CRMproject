using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace CIT280CRM.Models
{
    public class CRMDb : DbContext
    {
        public CRMDb() : base("CRMDb")
        {

        }

        
    }
}