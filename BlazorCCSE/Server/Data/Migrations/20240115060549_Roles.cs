using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorCCSE.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    singlePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    doublePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    familyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    singleRooms = table.Column<int>(type: "int", nullable: false),
                    doubleRooms = table.Column<int>(type: "int", nullable: false),
                    familyRooms = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    length = table.Column<int>(type: "int", nullable: false),
                    spaces = table.Column<int>(type: "int", nullable: false),
                    cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    forename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passportNumber = table.Column<int>(type: "int", nullable: false),
                    contactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HotelBookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hotelID = table.Column<int>(type: "int", nullable: false),
                    roomType = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: true),
                    totalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    depositPaid = table.Column<bool>(type: "bit", nullable: false),
                    totalPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBookings", x => x.id);
                    table.ForeignKey(
                        name: "FK_HotelBookings_Hotels_hotelID",
                        column: x => x.hotelID,
                        principalTable: "Hotels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelBookings_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TourBookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tourID = table.Column<int>(type: "int", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: true),
                    totalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    depositPaid = table.Column<bool>(type: "bit", nullable: false),
                    totalPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourBookings", x => x.id);
                    table.ForeignKey(
                        name: "FK_TourBookings_Tours_tourID",
                        column: x => x.tourID,
                        principalTable: "Tours",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourBookings_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "368157bb-84d8-4662-b164-4396254af751", null, "admin", "Admin" },
                    { "82d88018-18b0-44eb-bb4b-40ed1d01625c", null, "customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "id", "doublePrice", "doubleRooms", "familyPrice", "familyRooms", "name", "singlePrice", "singleRooms" },
                values: new object[,]
                {
                    { 1, 775m, 20, 950m, 20, "Hilton London Hotel", 375m, 20 },
                    { 2, 500m, 20, 900m, 20, "London Marriott Hotel", 300m, 20 },
                    { 3, 120m, 20, 150m, 20, "Travelodge Brighton Seafront", 80m, 20 },
                    { 4, 400m, 20, 520m, 20, "Kings Hotel Brighton", 180m, 20 },
                    { 5, 400m, 20, 520m, 20, "Leonardo Hotel Brighton", 180m, 20 },
                    { 6, 100m, 20, 155m, 20, "Nevis Bank Inn, Fort William", 90m, 20 }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "id", "cost", "length", "name", "spaces" },
                values: new object[,]
                {
                    { 1, 1200m, 6, "Real Britan", 30 },
                    { 2, 2000m, 16, "Britain and Ireland Explorer", 40 },
                    { 3, 2900m, 12, "Best of Britain", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_hotelID",
                table: "HotelBookings",
                column: "hotelID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_userid",
                table: "HotelBookings",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_TourBookings_tourID",
                table: "TourBookings",
                column: "tourID");

            migrationBuilder.CreateIndex(
                name: "IX_TourBookings_userid",
                table: "TourBookings",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelBookings");

            migrationBuilder.DropTable(
                name: "TourBookings");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "368157bb-84d8-4662-b164-4396254af751");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82d88018-18b0-44eb-bb4b-40ed1d01625c");
        }
    }
}
