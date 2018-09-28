using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monona.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monona.Data.Configurations
{
    internal class GoogleCategoryConfiguration : IEntityTypeConfiguration<GoogleCategory>
    {
        public void Configure(EntityTypeBuilder<GoogleCategory> builder)
        {
            builder.ToTable("GoogleCategories");

            builder.HasIndex(g => g.Name).HasName("IX_Name");
            builder.HasIndex(g => new { g.Enabled, g.Name }).HasName("IX_Enabled");
        }
    }
}
