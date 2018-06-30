﻿// <auto-generated />
using finalproject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace finalproject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180527070317_AdMNEW")]
    partial class AdMNEW
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("finalproject.Models.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("CNIC")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Passwordresettoken");

                    b.Property<string>("Role");

                    b.Property<string>("userimages");

                    b.HasKey("ID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("finalproject.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AppointmentTime");

                    b.Property<int>("DoctorId");

                    b.Property<int>("PatientId");

                    b.HasKey("AppointmentId");

                    b.HasIndex("DoctorId")
                        .IsUnique();

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("finalproject.Models.DietPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("Description");

                    b.Property<string>("DietName");

                    b.Property<int?>("PatientsPId");

                    b.Property<int>("pateintID");

                    b.HasKey("Id");

                    b.HasIndex("PatientsPId");

                    b.ToTable("DietPlans");
                });

            modelBuilder.Entity("finalproject.Models.DiseaseHistory", b =>
                {
                    b.Property<int>("DisHisID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DiseaseName");

                    b.Property<string>("Type");

                    b.Property<string>("duration");

                    b.Property<int>("patientId");

                    b.HasKey("DisHisID");

                    b.HasIndex("patientId");

                    b.ToTable("DiseaseHistories");
                });

            modelBuilder.Entity("finalproject.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("CNIC")
                        .HasMaxLength(11);

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("Email");

                    b.Property<string>("Hospital");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("PasswordResetToken");

                    b.Property<string>("Qualification");

                    b.Property<string>("Role");

                    b.Property<string>("Specialization");

                    b.Property<string>("Timings");

                    b.Property<string>("userimages");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("finalproject.Models.MedicalRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PatientId");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("images");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalRecords");
                });

            modelBuilder.Entity("finalproject.Models.Patient", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("CNIC")
                        .IsRequired();

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("Disease");

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Password");

                    b.Property<string>("PasswordResetToken");

                    b.Property<string>("Role");

                    b.Property<string>("userimages");

                    b.HasKey("PId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("finalproject.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("CNIC")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("finalproject.Models.Appointment", b =>
                {
                    b.HasOne("finalproject.Models.Doctor", "doctor")
                        .WithOne("appointments")
                        .HasForeignKey("finalproject.Models.Appointment", "DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("finalproject.Models.Patient", "patient")
                        .WithOne("appointments")
                        .HasForeignKey("finalproject.Models.Appointment", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("finalproject.Models.DietPlan", b =>
                {
                    b.HasOne("finalproject.Models.Patient", "Patients")
                        .WithMany()
                        .HasForeignKey("PatientsPId");
                });

            modelBuilder.Entity("finalproject.Models.DiseaseHistory", b =>
                {
                    b.HasOne("finalproject.Models.Patient", "patient")
                        .WithMany()
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("finalproject.Models.MedicalRecord", b =>
                {
                    b.HasOne("finalproject.Models.Patient", "patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
