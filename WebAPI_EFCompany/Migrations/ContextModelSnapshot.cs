﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_EFCompany;

namespace WebAPI_EFCompany.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("WebAPI_EFCompany.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HeadId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HeadId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Дирекция"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Котельный цех"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ОППР"
                        });
                });

            modelBuilder.Entity("WebAPI_EFCompany.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PositionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PositionId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebAPI_EFCompany.Model.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Salary")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VacationDayCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            Name = "Директор",
                            Salary = 200000,
                            VacationDayCount = 56
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 1,
                            Name = "Секретарь руководителя",
                            Salary = 60000,
                            VacationDayCount = 28
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 1,
                            Name = "Заместитель директора по безопасности",
                            Salary = 80000,
                            VacationDayCount = 28
                        },
                        new
                        {
                            Id = 4,
                            DepartmentId = 1,
                            Name = "Заместитель директора по снабжению",
                            Salary = 80000,
                            VacationDayCount = 28
                        },
                        new
                        {
                            Id = 5,
                            DepartmentId = 1,
                            Name = "Заместитель директора по кадрам",
                            Salary = 80000,
                            VacationDayCount = 28
                        },
                        new
                        {
                            Id = 6,
                            DepartmentId = 2,
                            Name = "Начальник КЦ",
                            Salary = 70000,
                            VacationDayCount = 56
                        },
                        new
                        {
                            Id = 7,
                            DepartmentId = 2,
                            Name = "Начальник смены КЦ",
                            Salary = 60000,
                            VacationDayCount = 44
                        },
                        new
                        {
                            Id = 8,
                            DepartmentId = 2,
                            Name = "Старший машинист",
                            Salary = 55000,
                            VacationDayCount = 44
                        },
                        new
                        {
                            Id = 9,
                            DepartmentId = 2,
                            Name = "Машинист котлов",
                            Salary = 50000,
                            VacationDayCount = 44
                        },
                        new
                        {
                            Id = 10,
                            DepartmentId = 2,
                            Name = "Обходчик по котельному оборудованию",
                            Salary = 45000,
                            VacationDayCount = 44
                        },
                        new
                        {
                            Id = 11,
                            DepartmentId = 2,
                            Name = "Обходчик по мельничному оборудованию",
                            Salary = 40000,
                            VacationDayCount = 44
                        },
                        new
                        {
                            Id = 12,
                            DepartmentId = 2,
                            Name = "Обходчик по злоудалению",
                            Salary = 35000,
                            VacationDayCount = 44
                        },
                        new
                        {
                            Id = 13,
                            DepartmentId = 3,
                            Name = "Начальник ОППР",
                            Salary = 70000,
                            VacationDayCount = 28
                        },
                        new
                        {
                            Id = 14,
                            DepartmentId = 3,
                            Name = "Заместитель начальника ОППР",
                            Salary = 65000,
                            VacationDayCount = 28
                        },
                        new
                        {
                            Id = 15,
                            DepartmentId = 3,
                            Name = "Ведущий инженер ОППР",
                            Salary = 50000,
                            VacationDayCount = 28
                        },
                        new
                        {
                            Id = 16,
                            DepartmentId = 3,
                            Name = "Сметчик",
                            Salary = 55000,
                            VacationDayCount = 28
                        },
                        new
                        {
                            Id = 17,
                            DepartmentId = 3,
                            Name = "Инженер ОППР",
                            Salary = 45000,
                            VacationDayCount = 28
                        });
                });

            modelBuilder.Entity("WebAPI_EFCompany.Model.Department", b =>
                {
                    b.HasOne("WebAPI_EFCompany.Model.Employee", "Head")
                        .WithMany()
                        .HasForeignKey("HeadId");

                    b.Navigation("Head");
                });

            modelBuilder.Entity("WebAPI_EFCompany.Model.Employee", b =>
                {
                    b.HasOne("WebAPI_EFCompany.Model.Position", "Position")
                        .WithOne("Head")
                        .HasForeignKey("WebAPI_EFCompany.Model.Employee", "PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("WebAPI_EFCompany.Model.Member", "Member", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Age")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("FirstName")
                                .HasColumnType("TEXT");

                            b1.Property<string>("LastName")
                                .HasColumnType("TEXT");

                            b1.Property<string>("MiddleName")
                                .HasColumnType("TEXT");

                            b1.Property<string>("PassportNumber")
                                .HasColumnType("TEXT");

                            b1.Property<string>("PassportSeries")
                                .HasColumnType("TEXT");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.Navigation("Member");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("WebAPI_EFCompany.Model.Position", b =>
                {
                    b.HasOne("WebAPI_EFCompany.Model.Department", "Department")
                        .WithMany("Positions")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WebAPI_EFCompany.Model.Department", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("WebAPI_EFCompany.Model.Position", b =>
                {
                    b.Navigation("Head");
                });
#pragma warning restore 612, 618
        }
    }
}
