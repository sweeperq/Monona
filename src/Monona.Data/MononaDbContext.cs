using Microsoft.EntityFrameworkCore;
using Monona.Core.Entities;
using Monona.Data.Configurations;
using System.Linq;

namespace Monona.Data
{
    public class MononaDbContext : DbContext
    {
        public MononaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Set the default decimal scale and precision
            var decProps = builder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == (typeof(decimal)) || p.ClrType == (typeof(decimal?)));
            foreach (var prop in decProps)
            {
                prop.Relational().ColumnType = "decimal(18,4)";
            }

            builder.ApplyConfiguration(new AdjustmentTypeConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new GoogleCategoryConfiguration());
            builder.ApplyConfiguration(new MappingConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductInventoryConfiguration());
            builder.ApplyConfiguration(new StoreConfiguration());
            builder.ApplyConfiguration(new VendorConfiguration());
        }

        public DbSet<AdjustmentType> AdjustmentTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<GoogleCategory> GoogleCategories { get; set; }
        public DbSet<Mapping> Mappings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}
