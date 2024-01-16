using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorCCSE.Server.Migrations
{
    /// <inheritdoc />
    public partial class MultiPeopleTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70754ef1-8eec-45af-8364-e7306df40b35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8873cb9f-6a73-4de0-bdfc-6beabd6e9a04");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "1aea2d87-c26c-4172-b1ea-d390595a5bb7");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "1dd5fbae-116e-4c85-91e4-d90c94358e95");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "6111b57a-22bf-40da-be34-81d5f44bf96f");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "7ef20b5a-35c9-477e-8286-cf6f862ea3a6");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "bac9bf00-9143-480e-965d-1e3c969512cc");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "c4d57d13-7969-43ed-9105-f6e85c0d5a33");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "5d54c92c-7f28-4a6f-8c7b-ec52112ce1dd");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "905442b0-e3e2-4a48-9778-5ab0fe7ea690");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "c4573123-4ad1-4886-bd6e-e3165de8cfb3");

            migrationBuilder.AddColumn<int>(
                name: "people",
                table: "TourBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "people",
                table: "TourBookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "70754ef1-8eec-45af-8364-e7306df40b35", null, "customer", "Customer" },
                    { "8873cb9f-6a73-4de0-bdfc-6beabd6e9a04", null, "admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "id", "doublePrice", "doubleRooms", "familyPrice", "familyRooms", "name", "singlePrice", "singleRooms" },
                values: new object[,]
                {
                    { "1aea2d87-c26c-4172-b1ea-d390595a5bb7", 100m, 20, 155m, 20, "Nevis Bank Inn, Fort William", 90m, 20 },
                    { "1dd5fbae-116e-4c85-91e4-d90c94358e95", 120m, 20, 150m, 20, "Travelodge Brighton Seafront", 80m, 20 },
                    { "6111b57a-22bf-40da-be34-81d5f44bf96f", 400m, 20, 520m, 20, "Kings Hotel Brighton", 180m, 20 },
                    { "7ef20b5a-35c9-477e-8286-cf6f862ea3a6", 775m, 20, 950m, 20, "Hilton London Hotel", 375m, 20 },
                    { "bac9bf00-9143-480e-965d-1e3c969512cc", 500m, 20, 900m, 20, "London Marriott Hotel", 300m, 20 },
                    { "c4d57d13-7969-43ed-9105-f6e85c0d5a33", 400m, 20, 520m, 20, "Leonardo Hotel Brighton", 180m, 20 }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "id", "cost", "length", "name", "spaces" },
                values: new object[,]
                {
                    { "5d54c92c-7f28-4a6f-8c7b-ec52112ce1dd", 1200m, 6, "Real Britan", 30 },
                    { "905442b0-e3e2-4a48-9778-5ab0fe7ea690", 2000m, 16, "Britain and Ireland Explorer", 40 },
                    { "c4573123-4ad1-4886-bd6e-e3165de8cfb3", 2900m, 12, "Best of Britain", 30 }
                });
        }
    }
}
