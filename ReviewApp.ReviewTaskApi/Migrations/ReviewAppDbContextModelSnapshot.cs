﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReviewApp.Data;

#nullable disable

namespace ReviewApp.ReviewTaskApi.Migrations
{
    [DbContext(typeof(ReviewAppDbContext))]
    partial class ReviewAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReviewApp.Model.Quarter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("QuarterCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("QuarterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuarterCode")
                        .IsUnique();

                    b.ToTable("Quarters");
                });

            modelBuilder.Entity("ReviewApp.Model.ReviewTask", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("EmployeeComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EmployeeRating")
                        .HasColumnType("float");

                    b.Property<bool>("IsTaskCompleteDate")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTaskStartDate")
                        .HasColumnType("bit");

                    b.Property<string>("ManagerComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ManagerRating")
                        .HasColumnType("float");

                    b.Property<int>("PercentageComplete")
                        .HasColumnType("int");

                    b.Property<int>("QuarterId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("TaskCompleteDate")
                        .HasColumnType("date");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("TaskStartDate")
                        .HasColumnType("date");

                    b.Property<string>("TaskTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weightage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuarterId");

                    b.HasIndex("StatusId");

                    b.ToTable("ReviewTasks");
                });

            modelBuilder.Entity("ReviewApp.Model.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StatusCode")
                        .IsUnique();

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("ReviewApp.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ReviewApp.Model.ReviewTask", b =>
                {
                    b.HasOne("ReviewApp.Model.Quarter", "Quarter")
                        .WithMany()
                        .HasForeignKey("QuarterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReviewApp.Model.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quarter");

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
