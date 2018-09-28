﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monona.Data;

namespace Monona.Data.Migrations
{
    [DbContext(typeof(MononaDbContext))]
    [Migration("20180928034611_Countries")]
    partial class Countries
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
#pragma warning restore 612, 618
        }
    }
}
