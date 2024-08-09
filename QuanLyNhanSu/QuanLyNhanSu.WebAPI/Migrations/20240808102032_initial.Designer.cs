﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyNhanSu.Data.Context;

#nullable disable

namespace QuanLyNhanSu.WebAPI.Migrations
{
    [DbContext(typeof(QLNSContext))]
    [Migration("20240808102032_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("AccountId")
                        .HasName("PK__Account__349DA5A6E899A3D1");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.Cong", b =>
                {
                    b.Property<int>("CongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CongId"));

                    b.Property<TimeSpan>("CheckIn")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("CheckOut")
                        .HasColumnType("time");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayCham")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("CongId")
                        .HasName("PK__Cong__BE52BA818D8BFB08");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Cong");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("SalaryId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId")
                        .HasName("PK__Employee__7AD04F113C020FB1");

                    b.HasIndex("AccountId")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.HasIndex("PositionId");

                    b.HasIndex("SalaryId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.PhucLoi", b =>
                {
                    b.Property<int>("PhucLoiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhucLoiId"));

                    b.Property<decimal>("Money")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("PhucLoiType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("PhucLoiId")
                        .HasName("PK__PhucLoi__E041D7C45D45EFCF");

                    b.ToTable("PhucLoi");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PositionId"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("HeSo")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("PhucLoiId")
                        .HasColumnType("int");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("PositionId")
                        .HasName("PK__Position__60BB9A79B67833A8");

                    b.HasIndex("PhucLoiId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.Salary", b =>
                {
                    b.Property<int>("SalaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalaryId"));

                    b.Property<decimal>("Money")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("SalaryType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("SalaryId")
                        .HasName("PK__Salary__4BE204572E084E79");

                    b.ToTable("Salary");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"));

                    b.Property<string>("AfternoonActivity")
                        .HasColumnType("text");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EveningActivity")
                        .HasColumnType("text");

                    b.Property<string>("MorningActivity")
                        .HasColumnType("text");

                    b.Property<DateTime>("WorkingDate")
                        .HasColumnType("date");

                    b.HasKey("ScheduleId")
                        .HasName("PK__Schedule__9C8A5B4926A8D27B");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.Cong", b =>
                {
                    b.HasOne("QuanLyNhanSu.Models.Entities.Employee", "Employee")
                        .WithMany("Congs")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_EmployeeAttendance");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.Employee", b =>
                {
                    b.HasOne("QuanLyNhanSu.Models.Entities.Account", "Account")
                        .WithOne("Employee")
                        .HasForeignKey("QuanLyNhanSu.Models.Entities.Employee", "AccountId")
                        .HasConstraintName("FK_Account");

                    b.HasOne("QuanLyNhanSu.Models.Entities.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .HasConstraintName("FK_Position");

                    b.HasOne("QuanLyNhanSu.Models.Entities.Salary", "Salary")
                        .WithMany("Employees")
                        .HasForeignKey("SalaryId")
                        .HasConstraintName("FK_Salary");

                    b.Navigation("Account");

                    b.Navigation("Position");

                    b.Navigation("Salary");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.Position", b =>
                {
                    b.HasOne("QuanLyNhanSu.Models.Entities.PhucLoi", "PhucLoi")
                        .WithMany("Positions")
                        .HasForeignKey("PhucLoiId")
                        .HasConstraintName("FK_PhucLoi");

                    b.Navigation("PhucLoi");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.Schedule", b =>
                {
                    b.HasOne("QuanLyNhanSu.Models.Entities.Employee", "Employee")
                        .WithMany("Schedules")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_EmployeeSchedule");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.Account", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.Employee", b =>
                {
                    b.Navigation("Congs");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.PhucLoi", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.Position", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("QuanLyNhanSu.Models.Entities.Salary", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
