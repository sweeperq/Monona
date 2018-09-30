using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monona.Core.Entities;

namespace Monona.Data.Configurations
{
    internal class AdjustmentTypeConfiguration : IEntityTypeConfiguration<AdjustmentType>
    {
        public void Configure(EntityTypeBuilder<AdjustmentType> builder)
        {
            builder.ToTable("AdjustmentTypes");

            builder.HasIndex(a => a.Name).HasName("IX_Name");
            builder.HasIndex(a => new { a.Enabled, a.Name }).HasName("IX_Enabled");
        }
    }
}
