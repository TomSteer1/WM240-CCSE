using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorCCSE.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePackageBookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23e7ecfd-c6fb-4efb-a0a8-c8314daf493f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ed19121-6e77-4767-b705-c895ca3d319b");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "423ff734-3e88-496a-902f-b66842a75fa5");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "4cf1f7a9-3f0b-46b6-8dac-f8eaf5d1755b");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "90b562e1-4331-4b49-b7c0-8bb75b731c3b");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "91886a3d-d5a7-403b-bc73-68db36a086cf");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "c0e30551-1139-4f22-98cb-b035c19f51d2");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "de1c7d3a-29e5-4659-a51a-e2811e01499f");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "3573c727-0008-4f14-9f42-b8f2be4555aa");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "d2d28690-1edf-49ec-9071-860787340a91");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "f812ff25-f3dc-458a-8d3b-40ce5be06a67");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23e7ecfd-c6fb-4efb-a0a8-c8314daf493f", null, "admin", "Admin" },
                    { "2ed19121-6e77-4767-b705-c895ca3d319b", null, "customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "id", "doublePrice", "doubleRooms", "familyPrice", "familyRooms", "name", "singlePrice", "singleRooms" },
                values: new object[,]
                {
                    { "423ff734-3e88-496a-902f-b66842a75fa5", 500m, 20, 900m, 20, "London Marriott Hotel", 300m, 20 },
                    { "4cf1f7a9-3f0b-46b6-8dac-f8eaf5d1755b", 400m, 20, 520m, 20, "Kings Hotel Brighton", 180m, 20 },
                    { "90b562e1-4331-4b49-b7c0-8bb75b731c3b", 120m, 20, 150m, 20, "Travelodge Brighton Seafront", 80m, 20 },
                    { "91886a3d-d5a7-403b-bc73-68db36a086cf", 100m, 20, 155m, 20, "Nevis Bank Inn, Fort William", 90m, 20 },
                    { "c0e30551-1139-4f22-98cb-b035c19f51d2", 775m, 20, 950m, 20, "Hilton London Hotel", 375m, 20 },
                    { "de1c7d3a-29e5-4659-a51a-e2811e01499f", 400m, 20, 520m, 20, "Leonardo Hotel Brighton", 180m, 20 }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "id", "cost", "length", "name", "spaces" },
                values: new object[,]
                {
                    { "3573c727-0008-4f14-9f42-b8f2be4555aa", 1200m, 6, "Real Britan", 30 },
                    { "d2d28690-1edf-49ec-9071-860787340a91", 2900m, 12, "Best of Britain", 30 },
                    { "f812ff25-f3dc-458a-8d3b-40ce5be06a67", 2000m, 16, "Britain and Ireland Explorer", 40 }
                });
        }
    }
}
