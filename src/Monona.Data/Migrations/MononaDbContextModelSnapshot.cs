﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monona.Data;

namespace Monona.Data.Migrations
{
    [DbContext(typeof(MononaDbContext))]
    partial class MononaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Monona.Core.Entities.AdjustmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasName("IX_Name");

                    b.HasIndex("Enabled", "Name")
                        .HasName("IX_Enabled");

                    b.ToTable("AdjustmentTypes");
                });

            modelBuilder.Entity("Monona.Core.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Abbreviation")
                        .HasName("IX_Abbreviation");

                    b.HasIndex("Name")
                        .HasName("IX_Name");

                    b.HasIndex("Enabled", "Name")
                        .HasName("IX_Enabled");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Monona.Core.Entities.GoogleCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasName("IX_Name");

                    b.HasIndex("Enabled", "Name")
                        .HasName("IX_Enabled");

                    b.ToTable("GoogleCategories");
                });

            modelBuilder.Entity("Monona.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BoxSize")
                        .HasMaxLength(256);

                    b.Property<string>("Brand")
                        .HasMaxLength(256);

                    b.Property<string>("BulkWarehouseLocation")
                        .HasMaxLength(256);

                    b.Property<int>("CasePack");

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int?>("CountryOfOriginId");

                    b.Property<bool>("DisallowBackorder");

                    b.Property<bool>("Discontinued");

                    b.Property<bool>("Dropshipped");

                    b.Property<int?>("GoogleCategoryId");

                    b.Property<string>("Gtin")
                        .HasMaxLength(64);

                    b.Property<DateTimeOffset?>("LastPrintedOn");

                    b.Property<int?>("LeadDays");

                    b.Property<decimal?>("MaxLength")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Mpn")
                        .HasMaxLength(64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("NotInStoresExclude");

                    b.Property<string>("Notes");

                    b.Property<int>("ReorderPoint");

                    b.Property<bool>("Seasonal");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("StoreId");

                    b.Property<int>("VendorId");

                    b.Property<string>("VendorPartNumber")
                        .HasMaxLength(64);

                    b.Property<string>("WarehouseLocation")
                        .HasMaxLength(256);

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.HasIndex("CountryOfOriginId");

                    b.HasIndex("GoogleCategoryId");

                    b.HasIndex("Name")
                        .HasName("IX_Name");

                    b.HasIndex("Sku")
                        .IsUnique()
                        .HasName("UX_Sku");

                    b.HasIndex("StoreId");

                    b.HasIndex("VendorId");

                    b.HasIndex("WarehouseLocation")
                        .HasName("IX_WarehouseLocation");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Monona.Core.Entities.ProductInventory", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("AvailableQuantity");

                    b.Property<DateTimeOffset?>("NextPoOn");

                    b.Property<int>("OnOrderQuantity");

                    b.Property<int>("PotentialQuantity");

                    b.Property<int>("ReservedQuantity");

                    b.Property<int>("StockQuantity");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductId", "StockQuantity")
                        .HasName("IX_StockQuantity");

                    b.ToTable("ProductInventory");
                });

            modelBuilder.Entity("Monona.Core.Entities.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasMaxLength(16);

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Url")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Abbreviation")
                        .HasName("IX_Abbreviation");

                    b.HasIndex("Name")
                        .HasName("IX_Name");

                    b.HasIndex("Enabled", "Name")
                        .HasName("IX_Enabled");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Monona.Core.Entities.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("DefaultBrand")
                        .HasMaxLength(256);

                    b.Property<int?>("DefaultCountryOfOriginId");

                    b.Property<int?>("DefaultGoogleCategoryId");

                    b.Property<int?>("DefaultLeadDays");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Notes");

                    b.Property<string>("PaymentTerms");

                    b.Property<string>("PoEmailAddresses");

                    b.Property<string>("StripFromSkuForClient")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("DefaultCountryOfOriginId");

                    b.HasIndex("DefaultGoogleCategoryId");

                    b.HasIndex("Name")
                        .HasName("IX_Name");

                    b.HasIndex("Enabled", "Name")
                        .HasName("IX_Enabled");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("Monona.Core.Entities.Product", b =>
                {
                    b.HasOne("Monona.Core.Entities.Country", "CountryOfOrigin")
                        .WithMany()
                        .HasForeignKey("CountryOfOriginId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Monona.Core.Entities.GoogleCategory", "GoogleCategory")
                        .WithMany()
                        .HasForeignKey("GoogleCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Monona.Core.Entities.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Monona.Core.Entities.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Monona.Core.Entities.ProductInventory", b =>
                {
                    b.HasOne("Monona.Core.Entities.Product")
                        .WithOne("Inventory")
                        .HasForeignKey("Monona.Core.Entities.ProductInventory", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monona.Core.Entities.Vendor", b =>
                {
                    b.HasOne("Monona.Core.Entities.Country", "DefaultCountryOfOrigin")
                        .WithMany()
                        .HasForeignKey("DefaultCountryOfOriginId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Monona.Core.Entities.GoogleCategory", "DefaultGoogleCategory")
                        .WithMany()
                        .HasForeignKey("DefaultGoogleCategoryId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
