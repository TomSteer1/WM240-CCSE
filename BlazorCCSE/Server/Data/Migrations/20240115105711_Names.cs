using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorCCSE.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be481383-676b-4df4-97cc-a28e9273ce49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d833b9e8-f985-4137-acf6-3ab380e2fa5b");

            migrationBuilder.AddColumn<string>(
                name: "forename",
                table: "TourBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "surname",
                table: "TourBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "forename",
                table: "HotelBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "surname",
                table: "HotelBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ab7269a8-695b-42f9-a483-8c988861bfbb", null, "admin", "Admin" },
                    { "fb6216b0-5b6a-4965-910b-95e08546c73f", null, "customer", "Customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "forename",
                table: "TourBookings");

            migrationBuilder.DropColumn(
                name: "surname",
                table: "TourBookings");

            migrationBuilder.DropColumn(
                name: "forename",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "surname",
                table: "HotelBookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "be481383-676b-4df4-97cc-a28e9273ce49", null, "customer", "Customer" },
                    { "d833b9e8-f985-4137-acf6-3ab380e2fa5b", null, "admin", "Admin" }
                });
        }
    }
}
