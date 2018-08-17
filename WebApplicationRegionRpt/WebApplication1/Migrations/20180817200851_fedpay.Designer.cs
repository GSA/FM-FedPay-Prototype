﻿// <auto-generated />
using FEDPAYmgr.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FEDPAY.Migrations
{
    [DbContext(typeof(FEDPAYContext))]
    [Migration("20180817200851_fedpay")]
    partial class fedpay
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("fedpay")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FEDPAY.Models.Region", b =>
                {
                    b.Property<string>("REG_PO_SUFFIX")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("REG_FAIM_FB_REGION_CODE");

                    b.Property<string>("REG_FEDPAY_REGION_CODE");

                    b.Property<string>("REG_FSS_REGION_CODE");

                    b.Property<string>("REG_INFONET_REGION_CODE");

                    b.Property<decimal>("REG_ROUTING_ID");

                    b.HasKey("REG_PO_SUFFIX");

                    b.ToTable("Region");
                });
#pragma warning restore 612, 618
        }
    }
}