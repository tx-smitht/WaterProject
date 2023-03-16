﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WaterProject.Models;

namespace WaterProject.Migrations
{
    [DbContext(typeof(WaterProjectContext))]
    [Migration("20230313151118_AddDonationsTableTry2")]
    partial class AddDonationsTableTry2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("WaterProject.Models.BasketLineItem", b =>
                {
                    b.Property<int>("LineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DonationId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("LineID");

                    b.HasIndex("DonationId");

                    b.HasIndex("ProjectId");

                    b.ToTable("BasketLineItem");
                });

            modelBuilder.Entity("WaterProject.Models.Donation", b =>
                {
                    b.Property<int>("DonationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine3")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Anonymous")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Zip")
                        .HasColumnType("TEXT");

                    b.HasKey("DonationId");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("WaterProject.Models.Project", b =>
                {
                    b.Property<long>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProjectFunctionalityStatus")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectImpact")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProjectName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectPhase")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectRegionalProgram")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectType")
                        .HasColumnType("TEXT");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("WaterProject.Models.BasketLineItem", b =>
                {
                    b.HasOne("WaterProject.Models.Donation", null)
                        .WithMany("Lines")
                        .HasForeignKey("DonationId");

                    b.HasOne("WaterProject.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });
#pragma warning restore 612, 618
        }
    }
}
