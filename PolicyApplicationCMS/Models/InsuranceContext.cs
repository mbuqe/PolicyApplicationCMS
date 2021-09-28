using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PolicyApplicationCMS.Models
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext() : base("InsureDB")
        {

        }
        public virtual DbSet<Quotation> Quotations { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }        
        public virtual DbSet<Apply> Apply { get; set; }
    }
}