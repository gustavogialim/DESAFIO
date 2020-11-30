﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhascoalottoDesafio.Infraestrutura.UnitOfWork;

namespace PhascoalottoDesafio.Infraestrutura.Migrations
{
    [DbContext(typeof(DbUnitOfWork))]
    partial class DbUnitOfWorkModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("PhascoalottoDesafio.Dominio.Aggregates.ConfigurationAgg.Configuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ComissionPercentage")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("InterestType")
                        .HasColumnType("int");

                    b.Property<decimal>("InterestValue")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("MaxInstallments")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Configuration");
                });

            modelBuilder.Entity("PhascoalottoDesafio.Dominio.Aggregates.DebtAgg.Debt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DueDate");

                    b.Property<decimal>("FinalValue");

                    b.Property<int>("InstallmentsCount");

                    b.Property<decimal>("InterestValue");

                    b.Property<int>("LateDays");

                    b.Property<string>("OrientationPhone");

                    b.Property<decimal>("OriginalValue");

                    b.HasKey("Id");

                    b.ToTable("Debt");
                });

            modelBuilder.Entity("PhascoalottoDesafio.Dominio.Aggregates.DebtInstallmentAgg.DebtInstallment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DebtId");

                    b.Property<DateTime>("DueDate");

                    b.Property<decimal>("FinalValue");

                    b.HasKey("Id");

                    b.HasIndex("DebtId");

                    b.ToTable("DebtInstallment");
                });

            modelBuilder.Entity("PhascoalottoDesafio.Dominio.Aggregates.DebtInstallmentAgg.DebtInstallment", b =>
                {
                    b.HasOne("PhascoalottoDesafio.Dominio.Aggregates.DebtAgg.Debt", "Debt")
                        .WithMany("Installments")
                        .HasForeignKey("DebtId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}