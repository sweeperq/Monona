using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monona.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monona.Data.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasOne(p => p.Store).WithMany().HasForeignKey(p => p.StoreId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Vendor).WithMany().HasForeignKey(p => p.VendorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.CountryOfOrigin).WithMany().HasForeignKey(p => p.CountryOfOriginId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.GoogleCategory).WithMany().HasForeignKey(p => p.GoogleCategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Inventory).WithOne().HasForeignKey<ProductInventory>("ProductId");


            builder.HasIndex(p => p.Sku).IsUnique().HasName("UX_Sku");
            builder.HasIndex(p => p.Name).HasName("IX_Name");
            builder.HasIndex(p => p.WarehouseLocation).HasName("IX_WarehouseLocation");
        }
    }
}
