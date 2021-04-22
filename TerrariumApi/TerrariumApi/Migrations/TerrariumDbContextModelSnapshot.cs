﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TerrariumApi.DataAccess;

namespace TerrariumApi.Migrations
{
    [DbContext(typeof(TerrariumDbContext))]
    partial class TerrariumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("TerrariumApi.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfileDataDescription")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfileDataId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfileName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProfileDataId");

                    b.ToTable("ProfileSet");
                });

            modelBuilder.Entity("TerrariumApi.Models.ProfileData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("MaxAllowedCarbonDioxideLevel")
                        .HasColumnType("REAL");

                    b.Property<double>("MaxAllowedTemperature")
                        .HasColumnType("REAL");

                    b.Property<double>("MaxHumidityLevel")
                        .HasColumnType("REAL");

                    b.Property<double>("MinAllowedCarbonDioxideLevel")
                        .HasColumnType("REAL");

                    b.Property<double>("MinAllowedTemperature")
                        .HasColumnType("REAL");

                    b.Property<double>("MinHumidityLevel")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("ProfileDataSet");
                });

            modelBuilder.Entity("TerrariumApi.Models.ScheduledTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Repeated")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TerrariumDataSnapshotId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TerrariumId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TerrariumDataSnapshotId");

                    b.HasIndex("TerrariumId");

                    b.ToTable("ScheduledTasksSet");
                });

            modelBuilder.Entity("TerrariumApi.Models.Terrarium", b =>
                {
                    b.Property<int>("TerrariumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnimalName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TerrariumDataId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TerrariumName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TerrariumId");

                    b.HasIndex("TerrariumDataId");

                    b.HasIndex("UserId");

                    b.ToTable("TerrariumSet");
                });

            modelBuilder.Entity("TerrariumApi.Models.TerrariumData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CarbonDioxideLevel")
                        .HasColumnType("REAL");

                    b.Property<double>("HumidityLevel")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsArtificialLightOn")
                        .HasColumnType("INTEGER");

                    b.Property<double>("NaturalLightLevel")
                        .HasColumnType("REAL");

                    b.Property<double>("Temperature")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("TerrariumDataSet");
                });

            modelBuilder.Entity("TerrariumApi.Models.TerrariumDataSnapshot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CarbonDioxideLevel")
                        .HasColumnType("REAL");

                    b.Property<double>("HumidityLevel")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsArtificialLightOn")
                        .HasColumnType("INTEGER");

                    b.Property<double>("NaturalLightLevel")
                        .HasColumnType("REAL");

                    b.Property<double>("Temperature")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("TerrariumDataSnapshot");
                });

            modelBuilder.Entity("TerrariumApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserSet");
                });

            modelBuilder.Entity("TerrariumApi.Models.Profile", b =>
                {
                    b.HasOne("TerrariumApi.Models.ProfileData", "ProfileData")
                        .WithMany()
                        .HasForeignKey("ProfileDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfileData");
                });

            modelBuilder.Entity("TerrariumApi.Models.ScheduledTask", b =>
                {
                    b.HasOne("TerrariumApi.Models.TerrariumDataSnapshot", "TerrariumDataSnapshot")
                        .WithMany()
                        .HasForeignKey("TerrariumDataSnapshotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TerrariumApi.Models.Terrarium", null)
                        .WithMany("ScheduledTaskList")
                        .HasForeignKey("TerrariumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TerrariumDataSnapshot");
                });

            modelBuilder.Entity("TerrariumApi.Models.Terrarium", b =>
                {
                    b.HasOne("TerrariumApi.Models.TerrariumData", "TerrariumData")
                        .WithMany()
                        .HasForeignKey("TerrariumDataId");

                    b.HasOne("TerrariumApi.Models.User", null)
                        .WithMany("TerrariumList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TerrariumData");
                });

            modelBuilder.Entity("TerrariumApi.Models.Terrarium", b =>
                {
                    b.Navigation("ScheduledTaskList");
                });

            modelBuilder.Entity("TerrariumApi.Models.User", b =>
                {
                    b.Navigation("TerrariumList");
                });
#pragma warning restore 612, 618
        }
    }
}
