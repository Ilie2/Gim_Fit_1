﻿// <auto-generated />
using System;
using Backend_Gimfit.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend_Gimfit.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240623091817_Loginmodel")]
    partial class Loginmodel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend_Gimfit.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Subscription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TrainerId");

                    b.ToTable("Clients");

                    b.HasDiscriminator<string>("Role").HasValue("Client");
                });

            modelBuilder.Entity("Backend_Gimfit.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SubscriptionId");

                    b.HasIndex("TrainerId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Backend_Gimfit.Models.CourseSchedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseSchedules");
                });

            modelBuilder.Entity("Backend_Gimfit.Models.Subscription", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Backend_Gimfit.Models.Trainer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("ID");

                    b.ToTable("Trainers");

                    b.HasDiscriminator<string>("Role").HasValue("Trainer");
                });

            modelBuilder.Entity("ClientCourseSchedule", b =>
                {
                    b.Property<int>("ClientsID")
                        .HasColumnType("int");

                    b.Property<int>("CourseSchedulesID")
                        .HasColumnType("int");

                    b.HasKey("ClientsID", "CourseSchedulesID");

                    b.HasIndex("CourseSchedulesID");

                    b.ToTable("CourseScheduleClient", (string)null);
                });

            modelBuilder.Entity("Backend_Gimfit.Models.Client", b =>
                {
                    b.HasOne("Backend_Gimfit.Models.Trainer", "Trainer")
                        .WithMany("Clients")
                        .HasForeignKey("TrainerId");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Backend_Gimfit.Models.Course", b =>
                {
                    b.HasOne("Backend_Gimfit.Models.Subscription", "Subscription")
                        .WithMany("Courses")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend_Gimfit.Models.Trainer", "Trainer")
                        .WithMany("Courses")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Subscription");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Backend_Gimfit.Models.CourseSchedule", b =>
                {
                    b.HasOne("Backend_Gimfit.Models.Course", "ScheduledCourse")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ScheduledCourse");
                });

            modelBuilder.Entity("ClientCourseSchedule", b =>
                {
                    b.HasOne("Backend_Gimfit.Models.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend_Gimfit.Models.CourseSchedule", null)
                        .WithMany()
                        .HasForeignKey("CourseSchedulesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend_Gimfit.Models.Subscription", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Backend_Gimfit.Models.Trainer", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
