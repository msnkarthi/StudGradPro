/*
 Authors Name    : Karthikeyan Nagarajan & Bharath Kumar Pidapa
 
 File Name      :   DataManager.cs
 Description    :   Class helps to manage Student Records
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Data
{
    /// <summary>
    /// Class helps to manage Student Records
    /// </summary>
    public class UniversityDataManager
    {
        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        /// <value>
        /// The students.
        /// </value>
        public Student[] Students { private set; get; }

        /// <summary>
        /// Gets or sets the available courses.
        /// </summary>
        /// <value>
        /// The available courses.
        /// </value>
        public Course[] AvailableCourses { private set; get; }

        /// <summary>
        /// The student data parser
        /// </summary>
        private StudentDataParser studentDataParser = new StudentDataParser();

        /// <summary>
        /// Initializes a new instance of the <see cref="UniversityDataManager"/> class.
        /// </summary>
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

            
            Students = studentDataParser.GetStudents();
        }

        /// <summary>
        /// Stores the students.
        /// </summary>
        public void StoreStudents()
        {
            studentDataParser.UpdateStudents(Students);
        }

        /// <summary>
        /// Retrieves the students.
        /// </summary>
        public void RetrieveStudents()
        {
            Students = studentDataParser.GetStudents();
        }

        /// <summary>
        /// Gets the course by identifier.
        /// </summary>
        /// <param name="courseId">The course identifier.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Studentses the by course.
        /// </summary>
        /// <param name="Students">The students.</param>
        /// <param name="courseId">The course identifier.</param>
        /// <returns></returns>
        public StudentByCourse[] StudentsByCourse(List<Student> Students, int courseId)
        {
            List<StudentByCourse> studByCourses = new List<StudentByCourse>();

            foreach(Student student in Students)
            {
                studByCourses.Add(new StudentByCourse(student, courseId));
            }

            return studByCourses.ToArray();
        }

        /// <summary>
        /// Updates the student.
        /// </summary>
        /// <param name="studentByCourse">The student by course.</param>
        /// <returns></returns>
        public bool UpdateStudent(StudentByCourse studentByCourse)
        {
            var student = Students.Where(stud => stud.Id == studentByCourse.Id).Single();

            if (student == null)
            {
                return false;
            }

            //ActiveCourse = student.CoursesEnrolled.Where(item => item.Id == courseId).Single();

            return true;
        }
    }
}
