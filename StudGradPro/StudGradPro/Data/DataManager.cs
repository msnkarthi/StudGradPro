using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Data
{
    public class UniversityDataManager
    {
        public Student[] Students { private set; get; }
        public Course[] AvailableCourses { private set; get; }
        

        public UniversityDataManager()
        {
            GradeItem item1 = new GradeItem { Id = 501, Item = "Assignment1", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 101 };
            GradeItem item2 = new GradeItem { Id = 502, Item = "Assignment2", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 101 };
            GradeItem item3 = new GradeItem { Id = 503, Item = "Assignment3", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 101 };
            GradeItem item4 = new GradeItem { Id = 504, Item = "Quiz", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 101 };
            GradeItem item5 = new GradeItem { Id = 505, Item = "Project", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 101 };

            GradeItem item6 = new GradeItem { Id = 506, Item = "Forum1", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 102 };
            GradeItem item7 = new GradeItem { Id = 507, Item = "Quiz1", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 102 };
            GradeItem item8 = new GradeItem { Id = 508, Item = "Assignment1", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 102 };
            GradeItem item9 = new GradeItem { Id = 509, Item = "Quiz2", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 102 };
            GradeItem item10 = new GradeItem { Id = 510, Item = "FinalAssignment", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 102 };

            GradeItem[] Course1GradeItems = new GradeItem[5] { item1, item2, item3, item4, item5 };
            GradeItem[] Course2GradeItems = new GradeItem[5] { item6, item7, item8, item9, item10 };

            Course course1 = new Course { Id = 101, Name = "Software Engineering", Plan = Course1GradeItems, ProfessorFullName = "John Smith" };
            Course course2 = new Course { Id = 102, Name = "Big Data Architectures", Plan = Course2GradeItems, ProfessorFullName = "Jesse Michael" };

            AvailableCourses = new Course[] { course1, course2 };

            //Student student1 = new Student { Id = 10001, LastName = "XYZ", FirstName = "AB", Address = "Stree1", Gender = "ABC", EMail = "abc@def.com", Status = "Active", CoursesEnrolled = new Course[2]{ course1, course2 } };
            //Student student2 = new Student { Id = 10002, LastName = "XYZ", FirstName = "AB", Address = "Stree1", Gender = "ABC", EMail = "abc@def.com", Status = "Active", CoursesEnrolled = new Course[2] { course1, course2 } };

            StudentDataParser studentDataParser = new StudentDataParser();
            Students = studentDataParser.GetStudents();
        }

        public Course GetCourseById(int courseId)
        {
            foreach (Course course in AvailableCourses)
            {
                if (courseId == course.Id)
                {
                    return course;
                }
            }
            return null;
        }

        public StudentByCourse[] StudentsByCourse(List<Student> Students, int courseId)
        {
            List<StudentByCourse> studByCourses = new List<StudentByCourse>();

            foreach(Student student in Students)
            {
                studByCourses.Add(new StudentByCourse(student, courseId));
            }

            return studByCourses.ToArray();
        }
    }
}
