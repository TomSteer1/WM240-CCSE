using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorCCSE.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePackageBookings5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "packageID",
                table: "TourBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c20511d-6e09-452f-8274-9e3c662f7b1b", null, "admin", "Admin" },
                    { "6b96a7d1-50dd-40d1-a906-ceb43a5b53b0", null, "customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "id", "doublePrice", "doubleRooms", "familyPrice", "familyRooms", "name", "singlePrice", "singleRooms" },
                values: new object[,]
                {
                    { "1ab8e8af-9837-43a6-abe2-cb485c6ac463", 400m, 20, 520m, 20, "Kings Hotel Brighton", 180m, 20 },
                    { "20b0c82c-b5d9-4851-8521-fe4b170d39b2", 400m, 20, 520m, 20, "Leonardo Hotel Brighton", 180m, 20 },
                    { "4a058a60-0194-440a-bec6-789c83aace75", 500m, 20, 900m, 20, "London Marriott Hotel", 300m, 20 },
                    { "8f7538d1-c92c-4dcc-a738-27f8d2d16da9", 100m, 20, 155m, 20, "Nevis Bank Inn, Fort William", 90m, 20 },
                    { "9363a9fe-7646-487c-9b43-127080cc22de", 775m, 20, 950m, 20, "Hilton London Hotel", 375m, 20 },
                    { "c48f4729-ed7c-4e51-9520-3a3ea2ce4b0e", 120m, 20, 150m, 20, "Travelodge Brighton Seafront", 80m, 20 }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "id", "cost", "length", "name", "spaces" },
                values: new object[,]
                {
                    { "4db9756e-b58c-492a-ac62-c6fbfbddab1d", 2900m, 12, "Best of Britain", 30 },
                    { "78445f6b-da03-4937-a261-eb79310f3c60", 1200m, 6, "Real Britan", 30 },
                    { "cf9549e8-f08c-4a2e-a191-f37807e22a5d", 2000m, 16, "Britain and Ireland Explorer", 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c20511d-6e09-452f-8274-9e3c662f7b1b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b96a7d1-50dd-40d1-a906-ceb43a5b53b0");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "1ab8e8af-9837-43a6-abe2-cb485c6ac463");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "20b0c82c-b5d9-4851-8521-fe4b170d39b2");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "4a058a60-0194-440a-bec6-789c83aace75");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "8f7538d1-c92c-4dcc-a738-27f8d2d16da9");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "9363a9fe-7646-487c-9b43-127080cc22de");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: "c48f4729-ed7c-4e51-9520-3a3ea2ce4b0e");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "4db9756e-b58c-492a-ac62-c6fbfbddab1d");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "78445f6b-da03-4937-a261-eb79310f3c60");

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "id",
                keyValue: "cf9549e8-f08c-4a2e-a191-f37807e22a5d");

            migrationBuilder.AlterColumn<string>(
                name: "packageID",
                table: "TourBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
