using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monona.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monona.Data.Configurations
{
    internal class AdjustmentConfiguration : IEntityTypeConfiguration<Adjustment>
    {
        public void Configure(EntityTypeBuilder<Adjustment> builder)
        {
            builder.ToTable("Adjustments");

            builder.HasOne(a => a.AdjustmentType).WithMany().HasForeignKey(a => a.AdjustmentTypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Store).WithMany().HasForeignKey(a => a.StoreId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Product).WithMany().HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => a.ReferenceNumber).HasName("IX_ReferenceNumber");
            builder.HasIndex(a => new { a.ProductId, a.AdjustmentDate, a.AdjustmentTypeId }).HasName("IX_ProductAdjustmentsByDate");
        }
    }
}
