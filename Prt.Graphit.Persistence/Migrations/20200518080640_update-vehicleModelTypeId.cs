using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prt.Graphit.Persistence.Migrations
{
    public partial class updatevehicleModelTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleModelId",
                table: "VehicleModel");

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleModelTypeId",
                table: "VehicleModel",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleModelTypeId",
                table: "VehicleModel");

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleModelId",
                table: "VehicleModel",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
