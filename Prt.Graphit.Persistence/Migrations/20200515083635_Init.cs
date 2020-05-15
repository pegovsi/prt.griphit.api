using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prt.Graphit.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_Unit_Name",
                table: "Unit",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_SkuId",
                table: "Unit",
                column: "SkuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkuPicture");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Sku");

            migrationBuilder.DropTable(
                name: "SkuGroup");

            migrationBuilder.DropTable(
                name: "SkuType");
        }
    }
}
