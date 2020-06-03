using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prt.Graphit.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brigade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    DivisionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brigade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chassis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ManufacturerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chassis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    GarrisonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    IconLink = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Readiness = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrewHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CrewId = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garrison",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CoordinateX = table.Column<decimal>(nullable: false),
                    CoordinateY = table.Column<decimal>(nullable: false),
                    Rate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garrison", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkuGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    ParentSkuGroupId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkuGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkuGroup_SkuGroup_ParentSkuGroupId",
                        column: x => x.ParentSkuGroupId,
                        principalTable: "SkuGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkuType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkuType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subdivision",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    BrigadeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdivision", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesMilitaryOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesMilitaryOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeStateServiceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeStateServiceStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    VehicleModelTypeId = table.Column<Guid>(nullable: false),
                    ChassiId = table.Column<Guid>(nullable: false),
                    IconLink = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    IconLink = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    PictureLink = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EKPC",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    EKPCParentId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CodeEKPC = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    ActiveStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EKPC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EKPC_EKPC_EKPCParentId",
                        column: x => x.EKPCParentId,
                        principalTable: "EKPC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EKPC_ActiveStatus_ActiveStatusId",
                        column: x => x.ActiveStatusId,
                        principalTable: "ActiveStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KVTMO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CodeKVTMO = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    ActiveStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KVTMO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KVTMO_ActiveStatus_ActiveStatusId",
                        column: x => x.ActiveStatusId,
                        principalTable: "ActiveStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LevelManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    IsVCH = table.Column<bool>(nullable: false),
                    Independent = table.Column<bool>(nullable: false),
                    ActiveStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelManagement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelManagement_ActiveStatus_ActiveStatusId",
                        column: x => x.ActiveStatusId,
                        principalTable: "ActiveStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryRank",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    ActiveStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryRank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryRank_ActiveStatus_ActiveStatusId",
                        column: x => x.ActiveStatusId,
                        principalTable: "ActiveStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sku",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    ParentSkuId = table.Column<Guid>(nullable: true),
                    SkuGroupId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Designation = table.Column<string>(nullable: true),
                    SkuTypeId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sku_Sku_ParentSkuId",
                        column: x => x.ParentSkuId,
                        principalTable: "Sku",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sku_SkuGroup_SkuGroupId",
                        column: x => x.SkuGroupId,
                        principalTable: "SkuGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sku_SkuType_SkuTypeId",
                        column: x => x.SkuTypeId,
                        principalTable: "SkuType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryPosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    ActiveStatusId = table.Column<int>(nullable: false),
                    TypeStateServiceStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryPosition_ActiveStatus_ActiveStatusId",
                        column: x => x.ActiveStatusId,
                        principalTable: "ActiveStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MilitaryPosition_TypeStateServiceStatus_TypeStateServiceSta~",
                        column: x => x.TypeStateServiceStatusId,
                        principalTable: "TypeStateServiceStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    VehicleTypeId = table.Column<Guid>(nullable: false),
                    ChassiId = table.Column<Guid>(nullable: false),
                    ChassisId = table.Column<Guid>(nullable: true),
                    VehicleModelId = table.Column<Guid>(nullable: false),
                    VehicleNomberFactory = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    VehicleNomberRegister = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    VehicleNomberChassis = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    ManufacturerId = table.Column<Guid>(nullable: false),
                    YearOfIssue = table.Column<DateTime>(nullable: false),
                    GarrisonId = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    DivisionId = table.Column<Guid>(nullable: false),
                    SubdivisionId = table.Column<Guid>(nullable: false),
                    BrigadeId = table.Column<Guid>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    Mileage = table.Column<decimal>(nullable: false),
                    ShotsAmount = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    OperatingTime = table.Column<decimal>(nullable: false),
                    ConditionId = table.Column<Guid>(nullable: true),
                    Responsible = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    ReadoutDate = table.Column<DateTime>(nullable: false),
                    StartupDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Brigade_BrigadeId",
                        column: x => x.BrigadeId,
                        principalTable: "Brigade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_Chassis_ChassisId",
                        column: x => x.ChassisId,
                        principalTable: "Chassis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Condition_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Condition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Garrison_GarrisonId",
                        column: x => x.GarrisonId,
                        principalTable: "Garrison",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Subdivision_SubdivisionId",
                        column: x => x.SubdivisionId,
                        principalTable: "Subdivision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleModel_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryFormation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    LevelManagementId = table.Column<Guid>(nullable: true),
                    MilitaryNameUnit = table.Column<string>(nullable: true),
                    ActiveStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryFormation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryFormation_LevelManagement_LevelManagementId",
                        column: x => x.LevelManagementId,
                        principalTable: "LevelManagement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MilitaryFormation_MilitaryFormation_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MilitaryFormation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MilitaryFormation_ActiveStatus_ActiveStatusId",
                        column: x => x.ActiveStatusId,
                        principalTable: "ActiveStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkuPicture",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    SkuId = table.Column<Guid>(nullable: false),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkuPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkuPicture_Sku_SkuId",
                        column: x => x.SkuId,
                        principalTable: "Sku",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    SkuId = table.Column<Guid>(nullable: false),
                    Coefficient = table.Column<decimal>(nullable: false),
                    Base = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Sku_SkuId",
                        column: x => x.SkuId,
                        principalTable: "Sku",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Login = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    MiddleName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsConfirm = table.Column<bool>(nullable: false),
                    MilitaryRankId = table.Column<Guid>(nullable: true),
                    MilitaryFormationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_MilitaryFormation_MilitaryFormationId",
                        column: x => x.MilitaryFormationId,
                        principalTable: "MilitaryFormation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_MilitaryRank_MilitaryRankId",
                        column: x => x.MilitaryRankId,
                        principalTable: "MilitaryRank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    OrderNumber = table.Column<string>(maxLength: 16, nullable: true),
                    OrderDateStart = table.Column<DateTime>(nullable: false),
                    OrderDateFinish = table.Column<DateTime>(nullable: false),
                    TypesMilitaryOrderId = table.Column<Guid>(nullable: false),
                    VehicleId = table.Column<Guid>(nullable: false),
                    MilitaryFormationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crew_MilitaryFormation_MilitaryFormationId",
                        column: x => x.MilitaryFormationId,
                        principalTable: "MilitaryFormation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crew_TypesMilitaryOrder_TypesMilitaryOrderId",
                        column: x => x.TypesMilitaryOrderId,
                        principalTable: "TypesMilitaryOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crew_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountMilitaryPosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    AccountId = table.Column<Guid>(nullable: false),
                    MilitaryPositionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountMilitaryPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountMilitaryPosition_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountMilitaryPosition_MilitaryPosition_MilitaryPositionId",
                        column: x => x.MilitaryPositionId,
                        principalTable: "MilitaryPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrewPosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    MilitaryPositionId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: true),
                    CrewId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrewPosition_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CrewPosition_Crew_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crew",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CrewPosition_MilitaryPosition_MilitaryPositionId",
                        column: x => x.MilitaryPositionId,
                        principalTable: "MilitaryPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountMilitaryPosition_AccountId",
                table: "AccountMilitaryPosition",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountMilitaryPosition_MilitaryPositionId_AccountId",
                table: "AccountMilitaryPosition",
                columns: new[] { "MilitaryPositionId", "AccountId" });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Login",
                table: "Accounts",
                column: "Login");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_MilitaryFormationId",
                table: "Accounts",
                column: "MilitaryFormationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_MilitaryRankId",
                table: "Accounts",
                column: "MilitaryRankId");

            migrationBuilder.CreateIndex(
                name: "IX_Brigade_Name",
                table: "Brigade",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Chassis_Name",
                table: "Chassis",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_City_Name",
                table: "City",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Condition_Name",
                table: "Condition",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_MilitaryFormationId",
                table: "Crew",
                column: "MilitaryFormationId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_TypesMilitaryOrderId",
                table: "Crew",
                column: "TypesMilitaryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_VehicleId",
                table: "Crew",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewPosition_AccountId",
                table: "CrewPosition",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewPosition_CrewId",
                table: "CrewPosition",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewPosition_MilitaryPositionId",
                table: "CrewPosition",
                column: "MilitaryPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_Name",
                table: "Division",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_EKPC_EKPCParentId",
                table: "EKPC",
                column: "EKPCParentId");

            migrationBuilder.CreateIndex(
                name: "IX_EKPC_Name",
                table: "EKPC",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_EKPC_ActiveStatusId",
                table: "EKPC",
                column: "ActiveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Garrison_Name",
                table: "Garrison",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_KVTMO_Name",
                table: "KVTMO",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_KVTMO_ActiveStatusId",
                table: "KVTMO",
                column: "ActiveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelManagement_Name",
                table: "LevelManagement",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_LevelManagement_ActiveStatusId",
                table: "LevelManagement",
                column: "ActiveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_Name",
                table: "Manufacturer",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryFormation_LevelManagementId",
                table: "MilitaryFormation",
                column: "LevelManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryFormation_Name",
                table: "MilitaryFormation",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryFormation_ParentId",
                table: "MilitaryFormation",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryFormation_ActiveStatusId",
                table: "MilitaryFormation",
                column: "ActiveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPosition_Name",
                table: "MilitaryPosition",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPosition_ActiveStatusId",
                table: "MilitaryPosition",
                column: "ActiveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPosition_TypeStateServiceStatusId",
                table: "MilitaryPosition",
                column: "TypeStateServiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryRank_Name",
                table: "MilitaryRank",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryRank_ActiveStatusId",
                table: "MilitaryRank",
                column: "ActiveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Sku_Name",
                table: "Sku",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Sku_ParentSkuId",
                table: "Sku",
                column: "ParentSkuId");

            migrationBuilder.CreateIndex(
                name: "IX_Sku_SkuGroupId",
                table: "Sku",
                column: "SkuGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Sku_SkuTypeId",
                table: "Sku",
                column: "SkuTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SkuGroup_Name",
                table: "SkuGroup",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_SkuGroup_ParentSkuGroupId",
                table: "SkuGroup",
                column: "ParentSkuGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SkuPicture_SkuId",
                table: "SkuPicture",
                column: "SkuId");

            migrationBuilder.CreateIndex(
                name: "IX_SkuType_Name",
                table: "SkuType",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Subdivision_Name",
                table: "Subdivision",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_TypesMilitaryOrder_Name",
                table: "TypesMilitaryOrder",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_Name",
                table: "Unit",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_SkuId",
                table: "Unit",
                column: "SkuId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_BrigadeId",
                table: "Vehicle",
                column: "BrigadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ChassisId",
                table: "Vehicle",
                column: "ChassisId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CityId",
                table: "Vehicle",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ConditionId",
                table: "Vehicle",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_DivisionId",
                table: "Vehicle",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_GarrisonId",
                table: "Vehicle",
                column: "GarrisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ManufacturerId",
                table: "Vehicle",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Name",
                table: "Vehicle",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_SubdivisionId",
                table: "Vehicle",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleModelId",
                table: "Vehicle",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_Name",
                table: "VehicleModel",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleType_Name",
                table: "VehicleType",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountMilitaryPosition");

            migrationBuilder.DropTable(
                name: "CrewHistory");

            migrationBuilder.DropTable(
                name: "CrewPosition");

            migrationBuilder.DropTable(
                name: "EKPC");

            migrationBuilder.DropTable(
                name: "KVTMO");

            migrationBuilder.DropTable(
                name: "SkuPicture");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "MilitaryPosition");

            migrationBuilder.DropTable(
                name: "Sku");

            migrationBuilder.DropTable(
                name: "MilitaryRank");

            migrationBuilder.DropTable(
                name: "MilitaryFormation");

            migrationBuilder.DropTable(
                name: "TypesMilitaryOrder");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "TypeStateServiceStatus");

            migrationBuilder.DropTable(
                name: "SkuGroup");

            migrationBuilder.DropTable(
                name: "SkuType");

            migrationBuilder.DropTable(
                name: "LevelManagement");

            migrationBuilder.DropTable(
                name: "Brigade");

            migrationBuilder.DropTable(
                name: "Chassis");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "Garrison");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Subdivision");

            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropTable(
                name: "ActiveStatus");
        }
    }
}
