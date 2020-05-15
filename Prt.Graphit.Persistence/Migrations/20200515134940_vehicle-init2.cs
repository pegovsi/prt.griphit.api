using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prt.Graphit.Persistence.Migrations
{
    public partial class vehicleinit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    VehicleModelId = table.Column<Guid>(nullable: false),
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
                    BrigadeId = table.Column<Guid>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    Mileage = table.Column<decimal>(nullable: false),
                    ShotsAmount = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    OperatingTime = table.Column<decimal>(nullable: false),
                    ConditionId = table.Column<Guid>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Division_Name",
                table: "Division",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Garrison_Name",
                table: "Garrison",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_Name",
                table: "Manufacturer",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Subdivision_Name",
                table: "Subdivision",
                column: "Name");

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
                name: "Vehicle");

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
        }
    }
}
