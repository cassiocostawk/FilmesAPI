using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class Criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "ae6183de-7824-4b26-a664-c77f19dd6825");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "bd2e5d94-cda7-4292-9509-106586a94260", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f73845c9-9fec-4db8-9617-be086e228de8", "AQAAAAEAACcQAAAAEM+hwZnS1CQmTVSjVwK3I7cRcNj/b1+kQd4AFJz/WlRGryHeMQmijQO6OgeRuFnKbg==", "e8b2ebb5-69bd-4973-9b68-a39f9513b3e3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "e638ffb7-7f05-4b4a-9303-401e30671960");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f650868-30fc-4a05-81b7-9b2e4c8139c3", "AQAAAAEAACcQAAAAEBcvzu/tE7AInNDN/9XI613tYcKYp2CpIkGMzbvI/ozlqJi4L2A6/j94Np5d0tB9Fw==", "1d3cd455-5503-4708-9a23-72ca5e0ab159" });
        }
    }
}
