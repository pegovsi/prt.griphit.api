using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prt.Graphit.Persistence.Migrations
{
    public partial class addVehicleModelPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleModelPosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    MilitaryPositionId = table.Column<Guid>(nullable: false),
                    VehicleModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModelPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModelPosition_MilitaryPosition_MilitaryPositionId",
                        column: x => x.MilitaryPositionId,
                        principalTable: "MilitaryPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleModelPosition_VehicleModel_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModelPosition_MilitaryPositionId",
                table: "VehicleModelPosition",
                column: "MilitaryPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModelPosition_VehicleModelId",
                table: "VehicleModelPosition",
                column: "VehicleModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleModelPosition");
        }
    }
}
