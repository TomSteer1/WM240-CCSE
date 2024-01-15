using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorCCSE.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update15011418 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab7269a8-695b-42f9-a483-8c988861bfbb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb6216b0-5b6a-4965-910b-95e08546c73f");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "HotelBookings");

            migrationBuilder.CreateTable(
                name: "PackaegBookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    forename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    depositPaid = table.Column<bool>(type: "bit", nullable: false),
                    totalPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackaegBookings", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "765b45ba-6dd9-4218-be39-41e712a5c602", null, "admin", "Admin" },
                    { "fae10109-34d3-4ad1-b8b0-60c86230ca6b", null, "customer", "Customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackaegBookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "765b45ba-6dd9-4218-be39-41e712a5c602");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fae10109-34d3-4ad1-b8b0-60c86230ca6b");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "HotelBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ab7269a8-695b-42f9-a483-8c988861bfbb", null, "admin", "Admin" },
                    { "fb6216b0-5b6a-4965-910b-95e08546c73f", null, "customer", "Customer" }
                });
        }
    }
}
