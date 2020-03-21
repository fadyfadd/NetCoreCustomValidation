using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCustomValidation.DataContext
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("CT_COUNTRY");
            builder.HasKey(c => c.CountryCode);
            builder.Property(c => c.CountryCode).HasColumnName("CT_COUNTRY");
            builder.Property(c => c.CountryName).HasColumnName("CT_DESC");
        }
    }
}
