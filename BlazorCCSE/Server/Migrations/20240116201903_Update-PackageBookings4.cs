using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorCCSE.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePackageBookings4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "packageID",
                table: "TourBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "packageID",
                table: "HotelBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f58846a-d2e6-472e-a844-a4576043579b", null, "customer", "Customer" },
                    { "a27fc956-825b-47c9-90e7-6eca8e8dd5b8", null, "admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "id", "doublePrice", "doubleRooms", "familyPrice", "familyRooms", "name", "singlePrice", "singleRooms" },
                values: new object[,]
                {
                    { "0285c78b-fd34-47f5-bc08-46d19578cb1b", 100m, 20, 155m, 20, "Nevis Bank Inn, Fort William", 90m, 20 },
                    { "189be678-3351-4484-8073-745d579b7899", 500m, 20, 900m, 20, "London Marriott Hotel", 300m, 20 },
                    { "1aa1042e-5315-47fc-9b0b-c962ed082384", 400m, 20, 520m, 20, "Leonardo Hotel Brighton", 180m, 20 },
                    { "606603c6-cc56-421a-8df9-3c7380be4fd3", 400m, 20, 520m, 20, "Kings Hotel Brighton", 180m, 20 },
                    { "a54261fd-babe-4f96-9bba-dbfa085337f2", 775m, 20, 950m, 20, "Hilton London Hotel", 375m, 20 },
                    { "e12e47f5-2744-4f26-9b90-a3321f09e081", 120m, 20, 150m, 20, "Travelodge Brighton Seafront", 80m, 20 }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "id", "cost", "length", "name", "spaces" },
                values: new object[,]
                {
                    { "c66e258c-4296-49a0-b9dd-6465d29a60fb", 2900m, 12, "Best of Britain", 30 },
                    { "e6eecbd5-4aae-4c6b-8b1d-7526093987e3", 1200m, 6, "Real Britan", 30 },
                    { "f49bed85-70cb-470d-a2bc-d5243bde1f32", 2000m, 16, "Britain and Ireland Explorer", 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f58846a-d2e6-472e-a844-a4576043579b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a27fc956-825b-47c9-90e7-6eca8e8dd5b8");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "0285c78b-fd34-47f5-bc08-46d19578cb1b");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "189be678-3351-4484-8073-745d579b7899");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "1aa1042e-5315-47fc-9b0b-c962ed082384");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "606603c6-cc56-421a-8df9-3c7380be4fd3");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "a54261fd-babe-4f96-9bba-dbfa085337f2");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "e12e47f5-2744-4f26-9b90-a3321f09e081");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "c66e258c-4296-49a0-b9dd-6465d29a60fb");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "e6eecbd5-4aae-4c6b-8b1d-7526093987e3");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "f49bed85-70cb-470d-a2bc-d5243bde1f32");

            migrationBuilder.DropColumn(
                name: "packageID",
                table: "TourBookings");

            migrationBuilder.DropColumn(
                name: "packageID",
                table: "HotelBookings");

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
    }
}
