using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monona.Core.Entities;

namespace Monona.Data.Configurations
{
    internal class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("Vendors");

            builder.HasOne(v => v.DefaultCountryOfOrigin).WithMany().HasForeignKey(v => v.DefaultCountryOfOriginId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(v => v.DefaultGoogleCategory).WithMany().HasForeignKey(v => v.DefaultGoogleCategoryId).OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(v => v.Name).HasName("IX_Name");
            builder.HasIndex(v => new { v.Enabled, v.Name }).HasName("IX_Enabled");
        }
    }
}
