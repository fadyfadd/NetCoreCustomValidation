using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCustomValidation.DataContext
{
    public class FleetConfiguration : IEntityTypeConfiguration<Fleet>
    {
        public void Configure(EntityTypeBuilder<Fleet> builder)
        {
            builder.ToTable("CT_FLEETLOC_V");
            builder.HasKey(f => f.FleetId);
            builder.Property(f => f.FleetId).HasColumnName("FL_ID");
            builder.Property(f => f.AreaCode).HasColumnName("FL_AREA");
            builder.Property(f => f.FleetCommissionDate).HasColumnName("FL_COMMISS");
            builder.Property(f => f.FleetKindCode).HasColumnName("FL_KIND");
            builder.Property(f => f.FleetLandedCost).HasColumnName("FL_LANDEDCOST");
            builder.Property(f => f.FleetNo).HasColumnName("FL_FLEETNO");
            builder.Property(f => f.FleetSerial).HasColumnName("FL_SERIAL");
            builder.HasOne(f => f.FleetArea).WithMany(a => a.AreaFleets).HasForeignKey(f => new { AreaCode = f.AreaCode });
        }
    }
}
