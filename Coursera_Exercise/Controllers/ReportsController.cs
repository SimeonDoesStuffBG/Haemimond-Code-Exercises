using Coursera_Exercise.Data;
using Coursera_Exercise.DB_Views;
using Coursera_Exercise.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coursera_Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        CourseraExerciseContext _context;
        public ReportsController(CourseraExerciseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetReport(ReportParameters reportParameters)
        {
            List<StudentCredit> studentCredits = await _context.StudentCredits
                .FromSql($@"GetStudentCredits @StartDate = {reportParameters.StartDate}, @EndDate = {reportParameters.EndDate}")
                .ToListAsync();

            studentCredits = studentCredits.Where(credit => credit.Total_Credit >= reportParameters.MinCredit
                            && (reportParameters.Students.Length <= 0
                                || reportParameters.Students.Contains(credit.Student_PIN))
                            ).ToList();

            List<KeyValuePair<StudentCredit, List<CourseDetails>>> report = new List<KeyValuePair<StudentCredit, List<CourseDetails>>>();
            foreach (StudentCredit student in studentCredits)
            {
                List<CourseDetails> courseDetails = await _context.CourseDetails
                    .FromSql(@$"GetCourseDetails @StudentPIN = {student.Student_PIN}, @StartDate = {reportParameters.StartDate}, @EndDate = {reportParameters.EndDate}")
                    .ToListAsync();

                report.Add(new KeyValuePair<StudentCredit, List<CourseDetails>>(student, courseDetails));
                Console.WriteLine($"{student.Student_Name}, {student.Total_Credit}");
                foreach (CourseDetails details in courseDetails)
                {
                    Console.WriteLine($"    {details.Course_name}, {details.Total_time}, {details.Credit}, {details.Instructor_name}");
                }
            }
            return Ok(report);
        }

        private bool isDateBetween(DateTime testedDate, DateTime startDate, DateTime endDate)
        {
            return testedDate >= startDate && testedDate <= endDate;
        }
    }
}
