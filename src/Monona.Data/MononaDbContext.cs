using Microsoft.EntityFrameworkCore;
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

            builder.ApplyConfiguration(new CountryConfiguration());
        }
    }
}
