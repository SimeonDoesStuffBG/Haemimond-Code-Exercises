using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Technical_Request.Migrations
{
    /// <inheritdoc />
    public partial class InitModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "TechnicalServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    TimeOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalServices", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PIN = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponsiblePersons",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsiblePersons", x => new { x.ServiceId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_ResponsiblePersons_Employees_EmployeeId_id",
                        column: x=> x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponsiblePersons_TechnicalServices_serviceId_id",
                        column: x=>x.ServiceId,
                        principalTable: "TechnicalServices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceBlocks",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    BlockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBlocks", x => new { x.ServiceId, x.BlockId });
                    table.ForeignKey(
                        name: "FK_ServiceBlocks_TechnicalServices_serviceId_id",
                        column: x => x.ServiceId,
                        principalTable: "TechnicalServices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceBlocks_Blocks_blockId_id",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Parent = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Systems_Systems_Parent_id",
                        column: x => x.Parent,
                        principalTable: "Systems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction);
                });
            migrationBuilder.CreateTable(
                name: "ServiceSystems",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    SystemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSystems", x => new { x.ServiceId, x.SystemId });
                    table.ForeignKey(
                        name: "FK_ServiceSystems_TechnicalServices_serviceId_id",
                        column: x => x.ServiceId,
                        principalTable: "TechnicalServices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceSystems_Blocks_blockId_id",
                        column: x => x.SystemId,
                        principalTable: "Systems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_Code",
                table: "Blocks",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PIN",
                table: "Employees",
                column: "PIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResponsiblePersons_EmployeeID_ServiceId_Activity",
                table: "ResponsiblePersons",
                columns: new[] { "EmployeeID", "ServiceId", "Activity" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Systems_Code",
                table: "Systems",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ResponsiblePersons");

            migrationBuilder.DropTable(
                name: "ServiceBlocks");

            migrationBuilder.DropTable(
                name: "ServiceSystems");

            migrationBuilder.DropTable(
                name: "Systems");

            migrationBuilder.DropTable(
                name: "TechnicalServices");
        }
    }
}
