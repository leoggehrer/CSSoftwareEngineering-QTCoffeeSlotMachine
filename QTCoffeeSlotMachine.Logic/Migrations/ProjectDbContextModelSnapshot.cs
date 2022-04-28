﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QTCoffeeSlotMachine.Logic.DataContext;

#nullable disable

namespace QTCoffeeSlotMachine.Logic.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    partial class ProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QTCoffeeSlotMachine.Logic.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("SlotMachineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SlotMachineId");

                    b.ToTable("Products", "App");
                });

            modelBuilder.Entity("QTCoffeeSlotMachine.Logic.Entities.SlotMachine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("DepoteCoin10")
                        .HasColumnType("int");

                    b.Property<int>("DepoteCoin100")
                        .HasColumnType("int");

                    b.Property<int>("DepoteCoin20")
                        .HasColumnType("int");

                    b.Property<int>("DepoteCoin200")
                        .HasColumnType("int");

                    b.Property<int>("DepoteCoin5")
                        .HasColumnType("int");

                    b.Property<int>("DepoteCoin50")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Location")
                        .IsUnique();

                    b.ToTable("SlotMachines", "App");
                });

            modelBuilder.Entity("QTCoffeeSlotMachine.Logic.Entities.Product", b =>
                {
                    b.HasOne("QTCoffeeSlotMachine.Logic.Entities.SlotMachine", "SlotMachine")
                        .WithMany("Products")
                        .HasForeignKey("SlotMachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SlotMachine");
                });

            modelBuilder.Entity("QTCoffeeSlotMachine.Logic.Entities.SlotMachine", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}