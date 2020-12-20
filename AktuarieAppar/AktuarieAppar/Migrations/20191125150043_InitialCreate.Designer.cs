﻿// <auto-generated />
using System;
using AktuarieAppar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AktuarieAppar.Migrations
{
    [DbContext(typeof(DWAktuarieContext))]
    [Migration("20191125150043_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AktuarieAppar.Models.TillgangsAllokering", b =>
                {
                    b.Property<DateTime>("DWFromDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TATDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AssetClass")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("AVK_SEK_YTD")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("AssetAllocation")
                        .HasColumnType("float");

                    b.Property<decimal>("MV_SEK")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("SavedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DWFromDate", "TATDate", "AssetClass");

                    b.ToTable("TAT");
                });
#pragma warning restore 612, 618
        }
    }
}