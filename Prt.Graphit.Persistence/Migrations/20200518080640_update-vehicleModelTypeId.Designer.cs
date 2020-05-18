﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Prt.Graphit.Persistence;

namespace Prt.Graphit.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200518080640_update-vehicleModelTypeId")]
    partial class updatevehicleModelTypeId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.Sku", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Designation")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ParentSkuId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SkuGroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SkuTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.HasIndex("ParentSkuId");

                    b.HasIndex("SkuGroupId");

                    b.HasIndex("SkuTypeId");

                    b.ToTable("Sku");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.SkuGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ParentSkuGroupId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.HasIndex("ParentSkuGroupId");

                    b.ToTable("SkuGroup");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.SkuPicture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("SkuId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SkuId");

                    b.ToTable("SkuPicture");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.SkuType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("SkuType");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Base")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Coefficient")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<Guid>("SkuId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.HasIndex("SkuId");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Brigade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DivisionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Brigade");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Chassis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("ManufacturerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Chassis");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("GarrisonId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Condition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IconLink")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("Readiness")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Condition");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Division", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Division");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Garrison", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("CoordinateX")
                        .HasColumnType("numeric");

                    b.Property<decimal>("CoordinateY")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Rate")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Garrison");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Manufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Subdivision", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BrigadeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Subdivision");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BrigadeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChassiId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ChassisId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConditionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DivisionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GarrisonId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ManufacturerId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Mileage")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<decimal>("OperatingTime")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("ReadoutDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Responsible")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("ShotsAmount")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("StartupDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("SubdivisionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VehicleModelId")
                        .HasColumnType("uuid");

                    b.Property<string>("VehicleNomberChassis")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("VehicleNomberFactory")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("VehicleNomberRegister")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<Guid>("VehicleTypeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("YearOfIssue")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("BrigadeId");

                    b.HasIndex("ChassisId");

                    b.HasIndex("CityId");

                    b.HasIndex("ConditionId");

                    b.HasIndex("DivisionId");

                    b.HasIndex("GarrisonId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("Name");

                    b.HasIndex("SubdivisionId");

                    b.HasIndex("VehicleModelId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.VehicleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChassiId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IconLink")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("ShortName")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<Guid>("VehicleModelTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("VehicleModel");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.VehicleType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IconLink")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("PictureLink")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("VehicleType");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.Sku", b =>
                {
                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.Sku", "ParentSku")
                        .WithMany()
                        .HasForeignKey("ParentSkuId");

                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.SkuGroup", "SkuGroup")
                        .WithMany()
                        .HasForeignKey("SkuGroupId");

                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.SkuType", "SkuType")
                        .WithMany()
                        .HasForeignKey("SkuTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.SkuGroup", b =>
                {
                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.SkuGroup", "ParentSkuGroup")
                        .WithMany()
                        .HasForeignKey("ParentSkuGroupId");
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.SkuPicture", b =>
                {
                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.Sku", null)
                        .WithMany("SkuPictures")
                        .HasForeignKey("SkuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.Unit", b =>
                {
                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Sku.Entities.Sku", "Sku")
                        .WithMany("Units")
                        .HasForeignKey("SkuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Vehicle", b =>
                {
                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Brigade", "Brigade")
                        .WithMany()
                        .HasForeignKey("BrigadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Chassis", "Chassis")
                        .WithMany()
                        .HasForeignKey("ChassisId");

                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Condition", "Condition")
                        .WithMany()
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Division", "Division")
                        .WithMany()
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Garrison", "Garrison")
                        .WithMany()
                        .HasForeignKey("GarrisonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.Subdivision", "Subdivision")
                        .WithMany()
                        .HasForeignKey("SubdivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.VehicleModel", "VehicleModel")
                        .WithMany()
                        .HasForeignKey("VehicleModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
