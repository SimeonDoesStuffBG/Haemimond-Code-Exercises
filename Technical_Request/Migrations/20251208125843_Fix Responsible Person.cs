using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Technical_Request.Migrations
{
    /// <inheritdoc />
    public partial class FixResponsiblePerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponsiblePersons",
                table: "ResponsiblePersons");

            migrationBuilder.DropIndex(
                name: "IX_ResponsiblePersons_EmployeeId_ServiceId_Activity",
                table: "ResponsiblePersons");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PIN_DateAdded",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "PIN",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponsiblePersons",
                table: "ResponsiblePersons",
                columns: new[] { "ServiceId", "Activity" });

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 8, 14, 58, 43, 620, DateTimeKind.Local).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 8, 14, 58, 43, 622, DateTimeKind.Local).AddTicks(696));

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 8, 14, 58, 43, 622, DateTimeKind.Local).AddTicks(708));

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 8, 14, 58, 43, 622, DateTimeKind.Local).AddTicks(711));

            migrationBuilder.UpdateData(
                table: "TechnicalServices",
                keyColumn: "Id",
                keyValue: 5,
                column: "TimeOfCreation",
                value: new DateTime(2025, 12, 8, 14, 58, 43, 622, DateTimeKind.Local).AddTicks(713));

            migrationBuilder.CreateIndex(
                name: "IX_ResponsiblePersons_ServiceId_Activity",
                table: "ResponsiblePersons",
                columns: new[] { "ServiceId", "Activity" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PIN_DateAdded",
                table: "Employees",
                columns: new[] { "PIN", "DateAdded" },
                unique: true,
                descending: new[] { false, true },
                filter: "[PIN] IS NOT NULL AND [DateAdded] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponsiblePersons",
                table: "ResponsiblePersons");

            migrationBuilder.DropIndex(
                name: "IX_ResponsiblePersons_ServiceId_Activity",
                table: "ResponsiblePersons");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PIN_DateAdded",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "PIN",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponsiblePersons",
                table: "ResponsiblePersons",
                columns: new[] { "ServiceId", "EmployeeId" });

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
                name: "IX_ResponsiblePersons_EmployeeId_ServiceId_Activity",
                table: "ResponsiblePersons",
                columns: new[] { "EmployeeId", "ServiceId", "Activity" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PIN_DateAdded",
                table: "Employees",
                columns: new[] { "PIN", "DateAdded" },
                unique: true,
                descending: new[] { false, true });
        }
    }
}
