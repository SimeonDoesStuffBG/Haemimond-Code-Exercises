using Coursera_Exercise.DB_Views;
using Coursera_Exercise.Models;
using Microsoft.EntityFrameworkCore;

namespace Coursera_Exercise.Data
{
    public class CourseraExerciseContext:DbContext
    {
        public CourseraExerciseContext(DbContextOptions<CourseraExerciseContext> options):base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentsCourse { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<StudentCredit> StudentCredits { get; set; }
        public DbSet<CourseDetails> CourseDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student { PIN = "sahh12KJF3", First_name = "John", Last_name = "Doe", Time_created = new DateTime(2025, 12, 24) },
                new Student { PIN = "hjPe23Lmn4", First_name = "Rand", Last_name = "al'Thor", Time_created = new DateTime(2025, 12, 24) },
                new Student { PIN = "oopq34dda5", First_name = "Paul", Last_name = "Atreides", Time_created = new DateTime(2025, 12, 24) },
                new Student { PIN = "lkas45mkp6", First_name = "Frodo", Last_name = "Baggins", Time_created = new DateTime(2025, 12, 24) },
                new Student { PIN = "mnet56sda7", First_name = "James", Last_name = "Holden", Time_created = new DateTime(2025, 12, 24) }
            );

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, First_name = "Gandalf", Last_name = "The Gray", Time_created = new DateTime(2025, 12, 24) },
                new Instructor { Id = 2, First_name = "Moiraine", Last_name = "Sedai", Time_created = new DateTime(2025, 12, 24) },
                new Instructor { Id = 3, First_name = "Leto Atreides", Last_name = "The Second The Second", Time_created = new DateTime(2025, 12, 24) },
                new Instructor { Id = 4, First_name = "Archangel", Last_name = "Michael", Time_created = new DateTime(2025, 12, 24) },
                new Instructor { Id = 5, First_name = "Eda", Last_name = "Clawthorne", Time_created = new DateTime(2025, 12, 24) }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Programming basics", Instructor_id = 3, Total_time = 23, Credit = 20, Time_created = new DateTime(2025, 12, 24) },
                new Course { Id = 2, Name = "Object orianted programming", Instructor_id = 3, Total_time = 13, Credit = 1, Time_created = new DateTime(2025, 12, 24) },
                new Course { Id = 3, Name = "Parody", Instructor_id = 2, Total_time = 22, Credit = 22, Time_created = new DateTime(2025, 12, 24) },
                new Course { Id = 4, Name = "Creative Writing", Instructor_id = 5, Total_time = 43, Credit = 9, Time_created = new DateTime(2025, 12, 24) },
                new Course { Id = 5, Name = "Elvish", Instructor_id = 1, Total_time = 34, Credit = 23, Time_created = new DateTime(2025, 12, 24) }
            );

            modelBuilder.Entity<StudentCourse>().HasData(
                new StudentCourse { Student_pin = "hjPe23Lmn4", Course_id = 3, Completion_Date = null },
                new StudentCourse { Student_pin = "mnet56sda7", Course_id = 3, Completion_Date = new DateOnly(2023, 12, 9) },
                new StudentCourse { Student_pin = "mnet56sda7", Course_id = 4, Completion_Date = new DateOnly(2023, 12, 9) },
                new StudentCourse { Student_pin = "lkas45mkp6", Course_id = 3, Completion_Date = null },
                new StudentCourse { Student_pin = "hjPe23Lmn4", Course_id = 5, Completion_Date = null },
                new StudentCourse { Student_pin = "hjPe23Lmn4", Course_id = 1, Completion_Date = null },
                new StudentCourse { Student_pin = "sahh12KJF3", Course_id = 2, Completion_Date = null },
                new StudentCourse { Student_pin = "sahh12KJF3", Course_id = 4, Completion_Date = null },
                new StudentCourse { Student_pin = "mnet56sda7", Course_id = 5, Completion_Date = null },
                new StudentCourse { Student_pin = "oopq34dda5", Course_id = 4, Completion_Date = new DateOnly(2023, 12, 9) },
                new StudentCourse { Student_pin = "lkas45mkp6", Course_id = 1, Completion_Date = null },
                new StudentCourse { Student_pin = "mnet56sda7", Course_id = 2, Completion_Date = null },
                new StudentCourse { Student_pin = "sahh12KJF3", Course_id = 3, Completion_Date = new DateOnly(2023, 12, 9) },
                new StudentCourse { Student_pin = "hjPe23Lmn4", Course_id = 4, Completion_Date = new DateOnly(2023, 12, 9) },
                new StudentCourse { Student_pin = "mnet56sda7", Course_id = 1, Completion_Date = null }
            );

            modelBuilder.Entity<StudentCredit>().HasNoKey().ToView(nameof(StudentCredits));
            modelBuilder.Entity<CourseDetails>().HasNoKey().ToView(nameof(CourseDetails));

        }
    }
}
