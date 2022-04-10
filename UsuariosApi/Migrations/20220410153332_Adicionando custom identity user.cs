using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class Adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "482bf941-b5ec-442e-96cd-913f4e8f8141");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "25665393-4e73-49d8-9ce5-2206e69e9999");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7abd53e2-f788-4fa5-b7c7-36b1dc9b690d", "AQAAAAEAACcQAAAAEMuuPetm0GbfuWaxAdGiB4yP2gKIwr82aMA+e4Ab7ccZ8gzV+icnJzTbPXrPbnQO1A==", "91a568ee-f585-4988-a592-f48c31d7fa68" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "bd2e5d94-cda7-4292-9509-106586a94260");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "ae6183de-7824-4b26-a664-c77f19dd6825");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f73845c9-9fec-4db8-9617-be086e228de8", "AQAAAAEAACcQAAAAEM+hwZnS1CQmTVSjVwK3I7cRcNj/b1+kQd4AFJz/WlRGryHeMQmijQO6OgeRuFnKbg==", "e8b2ebb5-69bd-4973-9b68-a39f9513b3e3" });
        }
    }
}
