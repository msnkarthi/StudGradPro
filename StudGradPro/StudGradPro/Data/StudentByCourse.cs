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
    public class StudentByCourse : IStudent
    {
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string EMail { set; get; }
        public string Status { set; get; }
        public double TotalGrade { private set; get; }
        public double GPA { private set; get; }
        public string LetterGrade { get; private set; }
        public Course ActiveCourse { get; private set; }

        public static List<string> SortableColumns = new List<string>()
        {
            "Id", "FirstName", "LastName", "GPA/TotalGrade/LetterGrade"
        };

        public static List<string> SearchableColumns = new List<string>()
        {
            "Id", "FirstName", "LastName", "GPA", "TotalGrade", "LetterGrade"
        };

        private Grade grade = null;

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
