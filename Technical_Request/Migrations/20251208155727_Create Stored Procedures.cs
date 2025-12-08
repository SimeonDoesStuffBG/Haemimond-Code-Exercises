using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Technical_Request.Migrations
{
    /// <inheritdoc />
    public partial class CreateStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string GetSystems = @"CREATE PROCEDURE GetSystems @ServiceId int AS
                                        WITH SystemDesedents
                                        AS (SELECT Systems.Id, Systems.Code, CAST((Systems.Name) AS varchar(1000)) AS Name, Systems.Parent, ServiceSystems.ServiceId
                                        	FROM Systems
                                        	LEFT JOIN ServiceSystems
                                        	ON ServiceSystems.SystemId = Systems.Id
                                        	WHERE Systems.Parent IS NULL
                                        	UNION ALL
                                        	SELECT s.Id, s.Code, CAST((CONCAT_WS('.',d.Name, s.Name)) AS varchar(1000)) AS Name, s.Parent, ServiceSystems.ServiceId
                                        	FROM Systems s
                                        	INNER JOIN SystemDesedents d
                                        	ON s.Parent = d.Id
                                        	INNER JOIN ServiceSystems
                                        	ON s.Id = ServiceSystems.SystemId OR d.ServiceId = ServiceSystems.ServiceId)
                                        SELECT Distinct SystemDesedents.Name, SystemDesedents.Code
                                        FROM SystemDesedents
                                        WHERE ServiceId = @ServiceID";
            migrationBuilder.Sql(GetSystems);

            string GetBlocks = @"CREATE PROCEDURE GetBlocks @ServiceId int AS
                                            SELECT blocks.Name, blocks.Code
                                            FROM Blocks
                                            INNER JOIN ServiceBlocks
                                            ON ServiceBlocks.BlockId = blocks.Id
                                            WHERE ServiceBlocks.ServiceId = @ServiceId";
            migrationBuilder.Sql(GetBlocks);

            string GetResponsiblePersons = @"CREATE PROCEDURE GetResponsiblePersons @ServiceId int AS
                                                        SELECT CONCAT_WS(' ',Employees.FirstName, Employees.surname, Employees.LastName) AS Name, ResponsiblePersons.activity
                                                        FROM Employees
                                                        INNER JOIN ResponsiblePersons
                                                        ON ResponsiblePersons.EmployeeId = Employees.Id
                                                        WHERE ResponsiblePersons.ServiceId = @ServiceId";
            migrationBuilder.Sql(GetResponsiblePersons);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
