using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prt.Graphit.Persistence.Migrations
{
    public partial class Accounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Brigade_BrigadeId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Condition_ConditionId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<bool>(
                name: "IsApproved",
                table: "Vehicle",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ConditionId",
                table: "Vehicle",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "BrigadeId",
                table: "Vehicle",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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
                    Login = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsConfirm = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Brigade_BrigadeId",
                table: "Vehicle",
                column: "BrigadeId",
                principalTable: "Brigade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Condition_ConditionId",
                table: "Vehicle",
                column: "ConditionId",
                principalTable: "Condition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Brigade_BrigadeId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Condition_ConditionId",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.AlterColumn<long>(
                name: "IsApproved",
                table: "Vehicle",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<Guid>(
                name: "ConditionId",
                table: "Vehicle",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BrigadeId",
                table: "Vehicle",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Brigade_BrigadeId",
                table: "Vehicle",
                column: "BrigadeId",
                principalTable: "Brigade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Condition_ConditionId",
                table: "Vehicle",
                column: "ConditionId",
                principalTable: "Condition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
