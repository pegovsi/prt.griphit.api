using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prt.Graphit.Persistence.Migrations
{
    public partial class UserMasterData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeUserMasterData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    TypeData = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeUserMasterData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMasterData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    VehicleModelId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMasterData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMasterDataField",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    UserMasterDataId = table.Column<Guid>(nullable: false),
                    NameField = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    TypeUserMasterDataId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMasterDataField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMasterDataField_UserMasterData_UserMasterDataId",
                        column: x => x.UserMasterDataId,
                        principalTable: "UserMasterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMasterDataValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    UserMasterDataId = table.Column<Guid>(nullable: false),
                    UserMasterDataFieldId = table.Column<Guid>(nullable: false),
                    VehicleId = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMasterDataValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMasterDataValue_UserMasterDataField_UserMasterDataField~",
                        column: x => x.UserMasterDataFieldId,
                        principalTable: "UserMasterDataField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMasterDataValue_UserMasterData_UserMasterDataId",
                        column: x => x.UserMasterDataId,
                        principalTable: "UserMasterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_ChassiId",
                table: "VehicleModel",
                column: "ChassiId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_VehicleModelTypeId",
                table: "VehicleModel",
                column: "VehicleModelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMasterData_VehicleModelId",
                table: "UserMasterData",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMasterDataField_TypeUserMasterDataId",
                table: "UserMasterDataField",
                column: "TypeUserMasterDataId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMasterDataField_UserMasterDataId",
                table: "UserMasterDataField",
                column: "UserMasterDataId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMasterDataValue_UserMasterDataFieldId",
                table: "UserMasterDataValue",
                column: "UserMasterDataFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMasterDataValue_UserMasterDataId",
                table: "UserMasterDataValue",
                column: "UserMasterDataId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMasterDataValue_VehicleId",
                table: "UserMasterDataValue",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModel_Chassis_ChassiId",
                table: "VehicleModel",
                column: "ChassiId",
                principalTable: "Chassis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModel_VehicleType_VehicleModelTypeId",
                table: "VehicleModel",
                column: "VehicleModelTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModel_Chassis_ChassiId",
                table: "VehicleModel");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModel_VehicleType_VehicleModelTypeId",
                table: "VehicleModel");

            migrationBuilder.DropTable(
                name: "TypeUserMasterData");

            migrationBuilder.DropTable(
                name: "UserMasterDataValue");

            migrationBuilder.DropTable(
                name: "UserMasterDataField");

            migrationBuilder.DropTable(
                name: "UserMasterData");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModel_ChassiId",
                table: "VehicleModel");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModel_VehicleModelTypeId",
                table: "VehicleModel");
        }
    }
}
