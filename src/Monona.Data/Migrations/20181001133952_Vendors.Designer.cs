﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monona.Data;

namespace Monona.Data.Migrations
{
    [DbContext(typeof(MononaDbContext))]
    [Migration("20181001133952_Vendors")]
    partial class Vendors
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
