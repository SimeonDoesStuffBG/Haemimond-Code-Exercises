using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coursera_Exercise.Migrations
{
    /// <inheritdoc />
    public partial class CreateSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string GetCredits = @"CREATE PROCEDURE GetStudentCredits @StartDate datetime2, @EndDate datetime2 AS
                                            BEGIN
                                                SELECT Students.PIN as Student_PIN, CONCAT_WS(' ', Students.first_name, Students.Last_name) as student_name, SUM(Courses.Credit) as total_credit
                                                FROM Students
                                                LEFT JOIN StudentsCourse
                                                ON Students.PIN = StudentsCourse.Student_pin
                                                LEFT JOIN Courses
                                                ON StudentsCourse.Course_id = Courses.Id
                                                WHERE StudentsCourse.Completion_Date IS NOT NULL AND StudentsCourse.Completion_Date BETWEEN @StartDate AND @EndDate
                                                GROUP BY Students.PIN, Students.First_name, Students.Last_name;
                                            END";
            migrationBuilder.Sql(GetCredits);

            string GetDetaild = @"CREATE PROCEDURE GetCourseDetails @StudentPIN nchar(10), @StartDate datetime2, @EndDate datetime2 AS
                                            BEGIN 
                                               SELECT CourseDetails.*
                                                FROM CourseDetails
                                                RIGHT JOIN StudentsCourse
                                                ON CourseDetails.Course_Id = StudentsCourse.Course_id
                                                WHERE StudentsCourse.Student_pin = @StudentPIN AND StudentsCourse.Completion_Date IS NOT NULL AND StudentsCourse.Completion_Date BETWEEN @StartDate AND @EndDate
                                            END";
            migrationBuilder.Sql(GetDetaild);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
