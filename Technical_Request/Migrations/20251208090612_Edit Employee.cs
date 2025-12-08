using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Technical_Request.Migrations
{
    /// <inheritdoc />
    public partial class EditEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_PIN",
                table: "Employees");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2021, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 8, 11, 6, 12, 544, DateTimeKind.Local).AddTicks(5599));

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 8, 11, 6, 12, 545, DateTimeKind.Local).AddTicks(6908));

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 8, 11, 6, 12, 545, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 8, 11, 6, 12, 545, DateTimeKind.Local).AddTicks(6923));

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 5,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 8, 11, 6, 12, 545, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PIN_DateAdded",
                table: "Employees",
                columns: new[] { "PIN", "DateAdded" },
                unique: true,
                descending: new[] { false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_PIN_DateAdded",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 5, 17, 58, 58, 92, DateTimeKind.Local).AddTicks(1883));

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 5, 17, 58, 58, 93, DateTimeKind.Local).AddTicks(3602));

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 5, 17, 58, 58, 93, DateTimeKind.Local).AddTicks(3614));

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 5, 17, 58, 58, 93, DateTimeKind.Local).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 5,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 5, 17, 58, 58, 93, DateTimeKind.Local).AddTicks(3618));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PIN",
                table: "Employees",
                column: "PIN",
                unique: true);
        }
    }
}
