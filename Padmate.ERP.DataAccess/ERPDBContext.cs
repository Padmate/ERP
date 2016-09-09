using Padmate.ERP.DataAccess.DBConfiguration;
using Padmate.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padmate.ERP.DataAccess
{
    public class ERPDBContext : DbContext
    {
        public ERPDBContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<WebLog> WebLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new WebLogConfiguration());


        }

        public static ERPDBContext Create()
        {
            return new ERPDBContext();
        }
    }
}
