using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Technical_Request.Migrations
{
    /// <inheritdoc />
    public partial class SeedExtraData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ResponsiblePersons",
                columns: new[] { "Activity", "ServiceId", "EmployeeId" },
                values: new object[,]
                {
                    { "approval", 1, 1 },
                    { "confirmation", 1, 4 },
                    { "approval", 2, 2 },
                    { "confirmation", 2, 3 },
                    { "creation", 2, 5 },
                    { "verification", 2, 3 },
                    { "approval", 3, 5 },
                    { "creation", 3, 1 },
                    { "verification", 3, 2 },
                    { "verification", 4, 4 },
                    { "confirmation", 5, 1 },
                    { "creation", 5, 1 },
                    { "verification", 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "ServiceBlocks",
                columns: new[] { "BlockId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 5, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 3, 4 },
                    { 4, 4 },
                    { 5, 4 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "ServiceSystems",
                columns: new[] { "ServiceId", "SystemId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 4 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 5 }
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ResponsiblePersons",
                keyColumns: new[] { "Activity", "ServiceId" },
                keyValues: new object[] { "approval", 1 });

            migrationBuilder.DeleteData(
                table: "ResponsiblePersons",
                keyColumns: new[] { "Activity", "ServiceId" },
                keyValues: new object[] { "confirmation", 1 });

            migrationBuilder.DeleteData(
                table: "ResponsiblePersons",
                keyColumns: new[] { "Activity", "ServiceId" },
                keyValues: new object[] { "approval", 2 });

            migrationBuilder.DeleteData(
                table: "ResponsiblePersons",
                keyColumns: new[] { "Activity", "ServiceId" },
                keyValues: new object[] { "confirmation", 2 });

            migrationBuilder.DeleteData(
                table: "ResponsiblePersons",
                keyColumns: new[] { "Activity", "ServiceId" },
                keyValues: new object[] { "creation", 2 });

            migrationBuilder.DeleteData(
                table: "ResponsiblePersons",
                keyColumns: new[] { "Activity", "ServiceId" },
                keyValues: new object[] { "verification", 2 });

            migrationBuilder.DeleteData(
                table: "ResponsiblePersons",
                keyColumns: new[] { "Activity", "ServiceId" },
                keyValues: new object[] { "approval", 3 });

            migrationBuilder.DeleteData(
                table: "ResponsiblePersons",
                keyColumns: new[] { "Activity", "ServiceId" },
                keyValues: new object[] { "creation", 3 });

            migrationBuilder.DeleteData(
                table: "ResponsiblePersons",
                keyColumns: new[] { "Activity", "ServiceId" },
                keyValues: new object[] { "verification", 3 });

            migrationBuilder.DeleteData(
                table: "ResponsiblePersons",
                keyColumns: new[] { "Activity", "ServiceId" },
                keyValues: new object[] { "verification", 4 });

            migrationBuilder.DeleteData(
                table: "ResponsiblePersons",
                keyColumns: new[] { "Activity", "ServiceId" },
                keyValues: new object[] { "confirmation", 5 });

            migrationBuilder.DeleteData(
                table: "ResponsiblePersons",
                keyColumns: new[] { "Activity", "ServiceId" },
                keyValues: new object[] { "creation", 5 });

            migrationBuilder.DeleteData(
                table: "ResponsiblePersons",
                keyColumns: new[] { "Activity", "ServiceId" },
                keyValues: new object[] { "verification", 5 });

            migrationBuilder.DeleteData(
                table: "ServiceBlocks",
                keyColumns: new[] { "BlockId", "ServiceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ServiceBlocks",
                keyColumns: new[] { "BlockId", "ServiceId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ServiceBlocks",
                keyColumns: new[] { "BlockId", "ServiceId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ServiceBlocks",
                keyColumns: new[] { "BlockId", "ServiceId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ServiceBlocks",
                keyColumns: new[] { "BlockId", "ServiceId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ServiceBlocks",
                keyColumns: new[] { "BlockId", "ServiceId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ServiceBlocks",
                keyColumns: new[] { "BlockId", "ServiceId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ServiceBlocks",
                keyColumns: new[] { "BlockId", "ServiceId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ServiceBlocks",
                keyColumns: new[] { "BlockId", "ServiceId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "ServiceBlocks",
                keyColumns: new[] { "BlockId", "ServiceId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ServiceSystems",
                keyColumns: new[] { "ServiceId", "SystemId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ServiceSystems",
                keyColumns: new[] { "ServiceId", "SystemId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ServiceSystems",
                keyColumns: new[] { "ServiceId", "SystemId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ServiceSystems",
                keyColumns: new[] { "ServiceId", "SystemId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ServiceSystems",
                keyColumns: new[] { "ServiceId", "SystemId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ServiceSystems",
                keyColumns: new[] { "ServiceId", "SystemId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ServiceSystems",
                keyColumns: new[] { "ServiceId", "SystemId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ServiceSystems",
                keyColumns: new[] { "ServiceId", "SystemId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ServiceSystems",
                keyColumns: new[] { "ServiceId", "SystemId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ServiceSystems",
                keyColumns: new[] { "ServiceId", "SystemId" },
                keyValues: new object[] { 5, 5 });
        }
    }
}
