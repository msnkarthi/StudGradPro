/*
 Authors Name    : Karthikeyan Nagarajan & Bharath Kumar Pidapa
 
 File Name      :   StudentByCourse.cs
 Description    :   Class defines Student Properties by selected Course
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Data
{
    /// <summary>
    /// Helps to display Student recors by selected course
    /// </summary>
    /// <seealso cref="StudGradPro.Data.IStudent" />
    public class StudentByCourse : IStudent
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { set; get; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { set; get; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { set; get; }

        /// <summary>
        /// Gets or sets the e mail.
        /// </summary>
        /// <value>
        /// The e mail.
        /// </value>
        public string EMail { set; get; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { set; get; }

        /// <summary>
        /// Gets or sets the total grade.
        /// </summary>
        /// <value>
        /// The total grade.
        /// </value>
        public double TotalGrade { private set; get; }

        /// <summary>
        /// Gets or sets the gpa.
        /// </summary>
        /// <value>
        /// The gpa.
        /// </value>
        public double GPA { private set; get; }

        /// <summary>
        /// Gets the letter grade.
        /// </summary>
        /// <value>
        /// The letter grade.
        /// </value>
        public string LetterGrade { get; private set; }

        /// <summary>
        /// Gets the active course.
        /// </summary>
        /// <value>
        /// The active course.
        /// </value>
        public Course ActiveCourse { get; private set; }

        /// <summary>
        /// The sortable columns
        /// </summary>
        public static List<string> SortableColumns = new List<string>()
        {
            "Id", "FirstName", "LastName", "GPA/TotalGrade/LetterGrade"
        };

        /// <summary>
        /// The searchable columns
        /// </summary>
        public static List<string> SearchableColumns = new List<string>()
        {
            "Id", "FirstName", "LastName", "GPA", "TotalGrade", "LetterGrade"
        };

        /// <summary>
        /// The grade
        /// </summary>
        private Grade grade = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentByCourse"/> class.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <param name="courseId">The course identifier.</param>
        public StudentByCourse(Student student, int courseId)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;

            EMail = student.EMail;
            Status = student.Status;

            ActiveCourse = student.CoursesEnrolled.Where(item => item.Id == courseId).Single();

            var selectedCourse = MainWindow.DataManager.GetCourseById(courseId);

            TotalGrade = CalculateGrade(student, selectedCourse);
            grade = new Grade(TotalGrade);

            GPA = grade.Scale;
            LetterGrade = grade.LetterGrade;
        }

        /// <summary>
        /// Calculates the grade.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <param name="selectedCourse">The selected course.</param>
        /// <returns></returns>
        private double CalculateGrade(Student student, Course selectedCourse)
        {
            double totalGrade = 0;
            foreach (Course course in student.CoursesEnrolled)
            {
                if (course.Id == selectedCourse.Id)
                {
                    foreach (GradeItem gradeItem in course.Plan)
                    {
                        totalGrade += gradeItem.Grade;
                    }
                }
            }
            return totalGrade / selectedCourse.Plan.Length;
        }
    }
}
