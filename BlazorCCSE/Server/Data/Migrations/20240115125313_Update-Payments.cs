using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorCCSE.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "765b45ba-6dd9-4218-be39-41e712a5c602");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fae10109-34d3-4ad1-b8b0-60c86230ca6b");

            migrationBuilder.AddColumn<int>(
                name: "paymentid",
                table: "TourBookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "paymentid",
                table: "PackaegBookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "paymentid",
                table: "HotelBookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cardNumber = table.Column<int>(type: "int", nullable: false),
                    expiryMonth = table.Column<int>(type: "int", nullable: false),
                    expiryYear = table.Column<int>(type: "int", nullable: false),
                    cvv = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45264cec-f3f7-422e-bf43-20d98a7f7366", null, "customer", "Customer" },
                    { "b5e62997-9960-40d3-a387-4284cb3b3f7d", null, "admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourBookings_paymentid",
                table: "TourBookings",
                column: "paymentid");

            migrationBuilder.CreateIndex(
                name: "IX_PackaegBookings_paymentid",
                table: "PackaegBookings",
                column: "paymentid");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_paymentid",
                table: "HotelBookings",
                column: "paymentid");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelBookings_Payment_paymentid",
                table: "HotelBookings",
                column: "paymentid",
                principalTable: "Payment",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackaegBookings_Payment_paymentid",
                table: "PackaegBookings",
                column: "paymentid",
                principalTable: "Payment",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TourBookings_Payment_paymentid",
                table: "TourBookings",
                column: "paymentid",
                principalTable: "Payment",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelBookings_Payment_paymentid",
                table: "HotelBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_PackaegBookings_Payment_paymentid",
                table: "PackaegBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourBookings_Payment_paymentid",
                table: "TourBookings");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_TourBookings_paymentid",
                table: "TourBookings");

            migrationBuilder.DropIndex(
                name: "IX_PackaegBookings_paymentid",
                table: "PackaegBookings");

            migrationBuilder.DropIndex(
                name: "IX_HotelBookings_paymentid",
                table: "HotelBookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45264cec-f3f7-422e-bf43-20d98a7f7366");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5e62997-9960-40d3-a387-4284cb3b3f7d");

            migrationBuilder.DropColumn(
                name: "paymentid",
                table: "TourBookings");

            migrationBuilder.DropColumn(
                name: "paymentid",
                table: "PackaegBookings");

            migrationBuilder.DropColumn(
                name: "paymentid",
                table: "HotelBookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "765b45ba-6dd9-4218-be39-41e712a5c602", null, "admin", "Admin" },
                    { "fae10109-34d3-4ad1-b8b0-60c86230ca6b", null, "customer", "Customer" }
                });
        }
    }
}
