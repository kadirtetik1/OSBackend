﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OSBackend.Persistence.Contexts;

#nullable disable

namespace OSBackend.Persistence.Migrations
{
    [DbContext(typeof(OsBackendDbContext))]
    [Migration("20230721075622_mig_1")]
    partial class mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<Guid>("CoursesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uuid");

                    b.HasKey("CoursesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("OSBackend.Domain.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<string>("comments")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("course_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("duration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("field")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("max_student")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("OSBackend.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("academic_role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("e_mail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("grade_year")
                        .HasColumnType("integer");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("phone_number")
                        .HasColumnType("bigint");

                    b.Property<string>("profile_picture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("OSBackend.Domain.Entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ProfessionArea")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("academic_role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.Property<string>("e_mail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("phone_number")
                        .HasColumnType("bigint");

                    b.Property<string>("profile_picture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("OSBackend.Domain.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OSBackend.Domain.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OSBackend.Domain.Entities.Course", b =>
                {
                    b.HasOne("OSBackend.Domain.Entities.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("OSBackend.Domain.Entities.Teacher", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
