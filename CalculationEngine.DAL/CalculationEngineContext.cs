using CalculationEngine.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace CalculationEngine.DAL
{
    public class CalculationEngineContext : DbContext
    {
        public CalculationEngineContext(DbContextOptions<CalculationEngineContext> options)
              : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.PricePerUnit).HasPrecision(10, 2);
            modelBuilder.Entity<Product>().Property(p => p.PricePerCarton).HasPrecision(10, 2);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Product { get; set; }

    }
}
