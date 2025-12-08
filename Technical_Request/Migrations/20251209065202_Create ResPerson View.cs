using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Technical_Request.Migrations
{
    /// <inheritdoc />
    public partial class CreateResPersonView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string createResPersonActView = @"CREATE VIEW ResponsiblePersonActivities AS
                                                SELECT CONCAT_WS(' ',Employees.FirstName, Employees.surname, Employees.LastName) AS FullName, ResponsiblePersons.activity, ResponsiblePersons.ServiceId
                                                FROM Employees
                                                INNER JOIN ResponsiblePersons
                                                ON ResponsiblePersons.EmployeeId = Employees.Id";
            migrationBuilder.Sql(createResPersonActView);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
