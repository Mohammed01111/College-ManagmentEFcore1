﻿// <auto-generated />
using System;
using College_ManagmentEFcore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace College_ManagmentEFcore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("College_ManagmentEFcore.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("College_ManagmentEFcore.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("College_ManagmentEFcore.Models.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("College_ManagmentEFcore.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("College_ManagmentEFcore.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("College_ManagmentEFcore.Models.hostel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("hostels");
                });

            modelBuilder.Entity("College_ManagmentEFcore.Models.student", b =>
                {
                    b.Property<int>("SID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("HostelId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SID");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("HostelId");

                    b.ToTable("students");
                });

            modelBuilder.Entity("CourseFaculty", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "FacultyId");

                    b.HasIndex("FacultyId");

                    b.ToTable("CourseFaculty");
                });

            modelBuilder.Entity("Coursestudent", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsSID")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "StudentsSID");

                    b.HasIndex("StudentsSID");

                    b.ToTable("Coursestudent");
                });

            modelBuilder.Entity("Examstudent", b =>
                {
                    b.Property<int>("ExamsId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsSID")
                        .HasColumnType("int");

                    b.HasKey("ExamsId", "StudentsSID");

                    b.HasIndex("StudentsSID");

                    b.ToTable("Examstudent");
                });

            modelBuilder.Entity("College_ManagmentEFcore.Models.Course", b =>
                {
                    b.HasOne("College_ManagmentEFcore.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("College_ManagmentEFcore.Models.Exam", b =>
                {
                    b.HasOne("College_ManagmentEFcore.Models.Department", "Department")
                        .WithMany("Exams")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("College_ManagmentEFcore.Models.Faculty", b =>
                {
                    b.HasOne("College_ManagmentEFcore.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("College_ManagmentEFcore.Models.Subject", b =>
                {
                    b.HasOne("College_ManagmentEFcore.Models.Faculty", "Faculty")
                        .WithMany("Subjects")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("College_ManagmentEFcore.Models.student", b =>
                {
                    b.HasOne("College_ManagmentEFcore.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("College_ManagmentEFcore.Models.hostel", "Hostel")
                        .WithMany("Students")
                        .HasForeignKey("HostelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Hostel");
                });

            modelBuilder.Entity("CourseFaculty", b =>
                {
                    b.HasOne("College_ManagmentEFcore.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("College_ManagmentEFcore.Models.Faculty", null)
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Coursestudent", b =>
                {
                    b.HasOne("College_ManagmentEFcore.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("College_ManagmentEFcore.Models.student", null)
                        .WithMany()
                        .HasForeignKey("StudentsSID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examstudent", b =>
                {
                    b.HasOne("College_ManagmentEFcore.Models.Exam", null)
                        .WithMany()
                        .HasForeignKey("ExamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("College_ManagmentEFcore.Models.student", null)
                        .WithMany()
                        .HasForeignKey("StudentsSID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("College_ManagmentEFcore.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Exams");
                });

            modelBuilder.Entity("College_ManagmentEFcore.Models.Faculty", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("College_ManagmentEFcore.Models.hostel", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
