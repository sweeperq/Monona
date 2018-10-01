using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monona.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monona.Data.Configurations
{
    internal class ProductInventoryConfiguration : IEntityTypeConfiguration<ProductInventory>
    {
        public void Configure(EntityTypeBuilder<ProductInventory> builder)
        {
            builder.ToTable("ProductInventory");

            builder.HasIndex(i => new { i.ProductId, i.StockQuantity }).HasName("IX_StockQuantity");
        }
    }
}
