﻿// <auto-generated />
using System;
using HomeAccounting.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeAccounting.DataAccess.Migrations
{
    [DbContext(typeof(DbContextHome))]
    [Migration("20230927141008_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HomeAccounting.Data.Entities.Consumption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("ConsumptionTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConsumptionTypeId");

                    b.HasIndex("MemberId");

                    b.ToTable("Consumptions");
                });

            modelBuilder.Entity("HomeAccounting.Data.Entities.ConsumptionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConsumptionTypes");
                });

            modelBuilder.Entity("HomeAccounting.Data.Entities.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("SourceIncomeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("SourceIncomeId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("HomeAccounting.Data.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("FamilyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("HomeAccounting.Data.Entities.SourceIncome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SourceIncomes");
                });

            modelBuilder.Entity("HomeAccounting.DataAccess.Entities.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("HomeAccounting.Data.Entities.Consumption", b =>
                {
                    b.HasOne("HomeAccounting.Data.Entities.ConsumptionType", "ConsumptionType")
                        .WithMany("Consumptions")
                        .HasForeignKey("ConsumptionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeAccounting.Data.Entities.Member", "Member")
                        .WithMany("Consumptions")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsumptionType");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("HomeAccounting.Data.Entities.Income", b =>
                {
                    b.HasOne("HomeAccounting.Data.Entities.Member", "Member")
                        .WithMany("Incomes")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeAccounting.Data.Entities.SourceIncome", "SourceIncome")
                        .WithMany("Incomes")
                        .HasForeignKey("SourceIncomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("SourceIncome");
                });

            modelBuilder.Entity("HomeAccounting.Data.Entities.Member", b =>
                {
                    b.HasOne("HomeAccounting.DataAccess.Entities.Family", "family")
                        .WithMany("FamilyMember")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("family");
                });

            modelBuilder.Entity("HomeAccounting.Data.Entities.ConsumptionType", b =>
                {
                    b.Navigation("Consumptions");
                });

            modelBuilder.Entity("HomeAccounting.Data.Entities.Member", b =>
                {
                    b.Navigation("Consumptions");

                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("HomeAccounting.Data.Entities.SourceIncome", b =>
                {
                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("HomeAccounting.DataAccess.Entities.Family", b =>
                {
                    b.Navigation("FamilyMember");
                });
#pragma warning restore 612, 618
        }
    }
}
