using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monona.Core.Entities;

namespace Monona.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.HasIndex(c => c.Name).HasName("IX_Name");
            builder.HasIndex(c => c.Abbreviation).HasName("IX_Abbreviation");
            builder.HasIndex(c => new { c.Enabled, c.Name }).HasName("IX_Enabled");
        }
    }
}
