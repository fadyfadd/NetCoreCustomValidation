using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NetCoreCustomValidation.DataContext
{
    public class  DbDataContext : DbContext
    {
        public DbSet<Area> Areas { set; get; }
        public DbSet<Country> Countries { set; get; }

        public DbSet<Fleet> Fleets { set; get; }

        private String connectionString;
        public DbDataContext(String connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseOracle(this.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AreaConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new FleetConfiguration());
        }
    }
}
