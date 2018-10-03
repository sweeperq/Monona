using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monona.Core.Entities;

namespace Monona.Data.Configurations
{
    internal class ReportGroupItemConfiguration : IEntityTypeConfiguration<ReportGroupItem>
    {
        public void Configure(EntityTypeBuilder<ReportGroupItem> builder)
        {
            builder.ToTable("ReportGroupItems");

            builder.HasOne(i => i.ReportGroup).WithMany().HasForeignKey(i => i.ReportGroupId);
            builder.HasOne(i => i.Product).WithMany().HasForeignKey(i => i.ProductId);
        }
    }
}
