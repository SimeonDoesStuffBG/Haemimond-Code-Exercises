using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Technical_Request.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "ResponsiblePersons",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_ResponsiblePersons_EmployeeID_ServiceId_Activity",
                table: "ResponsiblePersons",
                newName: "IX_ResponsiblePersons_EmployeeId_ServiceId_Activity");

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "2344", "Block-1" },
                    { 2, "24312", "Block-2" },
                    { 3, "2554", "Block-3" },
                    { 4, "2332", "Block-4" },
                    { 5, "2445", "Block-5" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "PIN", "Surname" },
                values: new object[,]
                {
                    { 1, "John", "Connor", "2245666422", "Leo" },
                    { 2, "Anton", "Milev", "2243211422", "Tsvyatkov" },
                    { 3, "Hristo", "Kirilov", "2245663222", "Pavlov" },
                    { 4, "John", "Johnson", "2245556422", "Johnathan" },
                    { 5, "Mathew", "Powel", "2245006422", "Jacob" }
                });

            migrationBuilder.InsertData(
                table: "Systems",
                columns: new[] { "Id", "Code", "Name", "Parent" },
                values: new object[,]
                {
                    { 1, "2245", "System 1", null },
                    { 2, "2145", "System 2", null },
                    { 3, "2945", "System 3", 1 },
                    { 4, "2545", "System 4", null },
                    { 5, "3245", "System 5", 3 }
                });

            migrationBuilder.InsertData(
                table: "TechnicalServices",
                columns: new[] { "Id", "Description", "Name", "TimeOfCreation" },
                values: new object[,]
                {
                    { 1, "Desc", "Service 1", new DateTime(2025, 12, 5, 17, 58, 58, 92, DateTimeKind.Local).AddTicks(1883) },
                    { 2, "Descr", "Service 2", new DateTime(2025, 12, 5, 17, 58, 58, 93, DateTimeKind.Local).AddTicks(3602) },
                    { 3, "Descri", "Service 3", new DateTime(2025, 12, 5, 17, 58, 58, 93, DateTimeKind.Local).AddTicks(3614) },
                    { 4, "Descrip", "Service 4", new DateTime(2025, 12, 5, 17, 58, 58, 93, DateTimeKind.Local).AddTicks(3617) },
                    { 5, "Descript", "Service 5", new DateTime(2025, 12, 5, 17, 58, 58, 93, DateTimeKind.Local).AddTicks(3618) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Systems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Systems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Systems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Systems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Systems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "ResponsiblePersons",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_ResponsiblePersons_EmployeeId_ServiceId_Activity",
                table: "ResponsiblePersons",
                newName: "IX_ResponsiblePersons_EmployeeID_ServiceId_Activity");
        }
    }
}
