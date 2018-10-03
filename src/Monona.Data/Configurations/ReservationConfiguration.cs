using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monona.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monona.Data.Configurations
{
    internal class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");

            builder.HasOne(r => r.Store).WithMany().HasForeignKey(r => r.StoreId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.Product).WithMany().HasForeignKey(r => r.ProductId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
