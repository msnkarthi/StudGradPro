/*
 Authors Name    : Karthikeyan Nagarajan & Bharath Kumar Pidapa
 
 File Name      :   Student.cs
 Description    :   Class defines Student Type
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Data
{
    /// <summary>
    /// Student Type
    /// </summary>
    /// <seealso cref="StudGradPro.Data.IStudent" />
    public class Student : IStudent
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
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { set; get; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string Gender { set; get; }

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
        /// Determines whether this instance can sort.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance can sort; otherwise, <c>false</c>.
        /// </returns>
        public bool CanSort()
        {
            return true;
        }

        /// <summary>
        /// The courses enrolled
        /// </summary>
        public Course[] CoursesEnrolled;

        /// <summary>
        /// The sortable columns
        /// </summary>
        public static List<string> SortableColumns = new List<string>()
        {
            "Id", "FirstName", "LastName", "Status"
        };

        /// <summary>
        /// The searchable columns
        /// </summary>
        public static List<string> SearchableColumns = new List<string>()
        {
            "Id", "FirstName", "LastName", "Status"
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        public Student()
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

            this.Id = 10001;
            this.LastName = "";
            this.FirstName = "";
            this.Address = "";
            this.Gender = "Male";
            this.EMail = "";
            this.Status = "";

            CoursesEnrolled = new Course[2]
            {
                course1, course2
            };
        }
    }
}
