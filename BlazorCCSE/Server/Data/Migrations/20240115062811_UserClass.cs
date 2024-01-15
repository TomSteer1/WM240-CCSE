using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorCCSE.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelBookings_Users_userid",
                table: "HotelBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourBookings_Users_userid",
                table: "TourBookings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TourBookings_userid",
                table: "TourBookings");

            migrationBuilder.DropIndex(
                name: "IX_HotelBookings_userid",
                table: "HotelBookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "368157bb-84d8-4662-b164-4396254af751");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82d88018-18b0-44eb-bb4b-40ed1d01625c");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "TourBookings",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "HotelBookings",
                newName: "userID");

            migrationBuilder.AlterColumn<string>(
                name: "userID",
                table: "TourBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userID",
                table: "HotelBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "contactNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "forename",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "passportNumber",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "546d50ce-e5ef-4fff-afcd-53f32d58ca2c", null, "admin", "Admin" },
                    { "b607318b-6f84-4e3e-87f3-056d8b8b4016", null, "customer", "Customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "546d50ce-e5ef-4fff-afcd-53f32d58ca2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b607318b-6f84-4e3e-87f3-056d8b8b4016");

            migrationBuilder.DropColumn(
                name: "contactNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "forename",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "passportNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "surname",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "TourBookings",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "HotelBookings",
                newName: "userid");

            migrationBuilder.AlterColumn<int>(
                name: "userid",
                table: "TourBookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "userid",
                table: "HotelBookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    forename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passportNumber = table.Column<int>(type: "int", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "368157bb-84d8-4662-b164-4396254af751", null, "admin", "Admin" },
                    { "82d88018-18b0-44eb-bb4b-40ed1d01625c", null, "customer", "Customer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourBookings_userid",
                table: "TourBookings",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_userid",
                table: "HotelBookings",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelBookings_Users_userid",
                table: "HotelBookings",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TourBookings_Users_userid",
                table: "TourBookings",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
