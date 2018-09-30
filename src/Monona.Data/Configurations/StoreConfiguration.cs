using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monona.Core.Entities;

namespace Monona.Data.Configurations
{
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores");
            builder.HasIndex(s => s.Name).HasName("IX_Name");
            builder.HasIndex(s => s.Abbreviation).HasName("IX_Abbreviation");
            builder.HasIndex(s => new { s.Enabled, s.Name }).HasName("IX_Enabled");
        }
    }
}
