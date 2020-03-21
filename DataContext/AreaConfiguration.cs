using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCustomValidation.DataContext
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {

        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("CT_AREA");
            builder.HasKey(a => a.AreaCode);
            builder.Property(a => a.AreaCode).HasColumnName("AR_AREA");
            builder.Property(a => a.AreaName).HasColumnName("AR_DESC");
            builder.Property(a => a.CountryCode).HasColumnName("AR_COUNTRY");
            builder.HasOne(a => a.AreaCountry).WithMany(c => c.CountryAreas).HasForeignKey(a => new { CountryCode = a.CountryCode });

        }

    }
}
