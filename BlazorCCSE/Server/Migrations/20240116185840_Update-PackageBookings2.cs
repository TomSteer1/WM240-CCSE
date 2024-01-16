using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorCCSE.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePackageBookings2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dd539e8-562c-45a4-97cd-0a8667a1e548");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9bd4707-1dcb-49ec-b38d-1a1e45fba94c");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "09b65da5-255b-48f4-a3dd-def0226fd04c");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "0be9b21b-f815-4f9a-814c-8c25b5b48019");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "6f2215c4-ebff-434a-b4a7-7f782e5b5b5d");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "71640e3c-7aa0-4500-a543-e54a7bb8e5b6");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "73db7cb7-e14e-4fe1-8d5e-0f08b56ee938");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "b03d5d78-6644-473c-b0b3-244c2ef804f0");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "531cb335-a6e1-487d-aaeb-0fd43725cea2");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "dff14753-cdf8-4cd7-a9c1-6a73c32e065e");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "f66bd67c-379d-4f86-a2f3-9ef0ce381d79");

            migrationBuilder.AddColumn<string>(
                name: "hotelBookingID",
                table: "PackageBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tourBookingID",
                table: "PackageBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e82a7378-46e6-4865-8a9f-d3ed20bdfe3e", null, "admin", "Admin" },
                    { "fb625a24-ac56-4824-b1c8-7c4245dcaa64", null, "customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "id", "doublePrice", "doubleRooms", "familyPrice", "familyRooms", "name", "singlePrice", "singleRooms" },
                values: new object[,]
                {
                    { "161a1c73-6db0-4402-9318-e65898c7e531", 100m, 20, 155m, 20, "Nevis Bank Inn, Fort William", 90m, 20 },
                    { "643027c9-3028-4660-a39c-66a4bf499efc", 775m, 20, 950m, 20, "Hilton London Hotel", 375m, 20 },
                    { "6b0a3d6a-e29e-4c8b-9eae-198b4f85cba3", 120m, 20, 150m, 20, "Travelodge Brighton Seafront", 80m, 20 },
                    { "80b2209e-b80d-4afa-9b97-349370d310f2", 400m, 20, 520m, 20, "Leonardo Hotel Brighton", 180m, 20 },
                    { "822dc752-5a4d-4d32-8821-b5487afec16a", 500m, 20, 900m, 20, "London Marriott Hotel", 300m, 20 },
                    { "a09bdff3-670a-4cb4-9865-2b09b2b42c52", 400m, 20, 520m, 20, "Kings Hotel Brighton", 180m, 20 }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "id", "cost", "length", "name", "spaces" },
                values: new object[,]
                {
                    { "0d7e45a0-c97b-4996-8361-0c7e3fded5dd", 2900m, 12, "Best of Britain", 30 },
                    { "92f9e9a4-f6b8-4328-8bb7-a87ef0660c3b", 1200m, 6, "Real Britan", 30 },
                    { "d9ff272a-3f59-47ab-a33b-65e8477322c0", 2000m, 16, "Britain and Ireland Explorer", 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e82a7378-46e6-4865-8a9f-d3ed20bdfe3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb625a24-ac56-4824-b1c8-7c4245dcaa64");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "161a1c73-6db0-4402-9318-e65898c7e531");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "643027c9-3028-4660-a39c-66a4bf499efc");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "6b0a3d6a-e29e-4c8b-9eae-198b4f85cba3");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "80b2209e-b80d-4afa-9b97-349370d310f2");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "822dc752-5a4d-4d32-8821-b5487afec16a");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "a09bdff3-670a-4cb4-9865-2b09b2b42c52");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "0d7e45a0-c97b-4996-8361-0c7e3fded5dd");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "92f9e9a4-f6b8-4328-8bb7-a87ef0660c3b");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "d9ff272a-3f59-47ab-a33b-65e8477322c0");

            migrationBuilder.DropColumn(
                name: "hotelBookingID",
                table: "PackageBookings");

            migrationBuilder.DropColumn(
                name: "tourBookingID",
                table: "PackageBookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3dd539e8-562c-45a4-97cd-0a8667a1e548", null, "customer", "Customer" },
                    { "f9bd4707-1dcb-49ec-b38d-1a1e45fba94c", null, "admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "id", "doublePrice", "doubleRooms", "familyPrice", "familyRooms", "name", "singlePrice", "singleRooms" },
                values: new object[,]
                {
                    { "09b65da5-255b-48f4-a3dd-def0226fd04c", 775m, 20, 950m, 20, "Hilton London Hotel", 375m, 20 },
                    { "0be9b21b-f815-4f9a-814c-8c25b5b48019", 400m, 20, 520m, 20, "Leonardo Hotel Brighton", 180m, 20 },
                    { "6f2215c4-ebff-434a-b4a7-7f782e5b5b5d", 100m, 20, 155m, 20, "Nevis Bank Inn, Fort William", 90m, 20 },
                    { "71640e3c-7aa0-4500-a543-e54a7bb8e5b6", 500m, 20, 900m, 20, "London Marriott Hotel", 300m, 20 },
                    { "73db7cb7-e14e-4fe1-8d5e-0f08b56ee938", 400m, 20, 520m, 20, "Kings Hotel Brighton", 180m, 20 },
                    { "b03d5d78-6644-473c-b0b3-244c2ef804f0", 120m, 20, 150m, 20, "Travelodge Brighton Seafront", 80m, 20 }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "id", "cost", "length", "name", "spaces" },
                values: new object[,]
                {
                    { "531cb335-a6e1-487d-aaeb-0fd43725cea2", 2900m, 12, "Best of Britain", 30 },
                    { "dff14753-cdf8-4cd7-a9c1-6a73c32e065e", 2000m, 16, "Britain and Ireland Explorer", 40 },
                    { "f66bd67c-379d-4f86-a2f3-9ef0ce381d79", 1200m, 6, "Real Britan", 30 }
                });
        }
    }
}
