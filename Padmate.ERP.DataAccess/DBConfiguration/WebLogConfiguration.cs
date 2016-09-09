using Padmate.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padmate.ERP.DataAccess.DBConfiguration
{
    public class WebLogConfiguration : EntityTypeConfiguration<WebLog>
    {
        internal WebLogConfiguration()
        {
            this.ToTable("comWebLog");
            this.HasKey(m => m.ID);
            this.Property(m => m.TypeID).HasMaxLength(20);

        }
    }
}
