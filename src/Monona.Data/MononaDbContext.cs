using Microsoft.EntityFrameworkCore;
using Monona.Core.Entities;
using Monona.Data.Configurations;

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
            builder.ApplyConfiguration(new AdjustmentTypeConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new GoogleCategoryConfiguration());
            builder.ApplyConfiguration(new StoreConfiguration());

        }

        public DbSet<AdjustmentType> AdjustmentTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<GoogleCategory> GoogleCategories { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
