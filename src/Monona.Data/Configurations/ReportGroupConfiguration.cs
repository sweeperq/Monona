using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monona.Core.Entities;

namespace Monona.Data.Configurations
{
    internal class ReportGroupConfiguration : IEntityTypeConfiguration<ReportGroup>
    {
        public void Configure(EntityTypeBuilder<ReportGroup> builder)
        {
            builder.ToTable("ReportGroups");

            builder.HasIndex(g => g.Name).HasName("IX_Name");
        }
    }
}
